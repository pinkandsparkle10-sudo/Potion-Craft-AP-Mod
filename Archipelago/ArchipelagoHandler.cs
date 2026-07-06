using ApClient;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.MessageLog.Messages;
using Archipelago.MultiClient.Net.MessageLog.Parts;
using Archipelago.MultiClient.Net.Models;
using PotionCraft.ManagersSystem.Game;
using PotionCraft.ScriptableObjects.Talents;
using PotionCraftAPMod.Archipelago;
using PotionCraftAPMod.Handlers;
using PotionCraftAPMod.UI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

namespace PotionCraftAPMod.Archipelago;

public class ArchipelagoHandler : MonoBehaviour
{

    private static ArchipelagoHandler _instance;
    public static ArchipelagoHandler Instance
    {
        get
        {
            if (_instance == null)
                throw new Exception("ArchipelagoHandler instance is null. Make sure it is initialized in the scene.");
            return _instance!;
        }
        set { _instance = value; }
    }

    public SlotData slotData;
    public SaveHandler saveHandler;
    private ArchipelagoSession Session { get; set; }
    private DeathLinkService deathLinkService = null;

    public bool disconnecting = false;

    public bool IsConnected => Session?.Socket.Connected ?? false;

    public async Task<bool> ConnectAsync(string ip, string password, string slot)
    {
        Session = ArchipelagoSessionFactory.CreateSession(ip);
        Session.MessageLog.OnMessageReceived += OnMessageReceived;
        Session.Socket.ErrorReceived += OnError;
        Session.Socket.SocketClosed += OnSocketClosed;
        Session.Items.ItemReceived += ItemReceived;

        LoginResult result = null;
        try
        {
            result = Session.TryConnectAndLogin("Potion Craft", slot, ItemsHandlingFlags.AllItems, null, null, null, password, true);
        }
        catch (Exception ex)
        {
            ConnectionMenu.SetState("Connnection Failed", true);
            return false;
        }

        if (result.Successful)
        {
            var loginSuccess = (LoginSuccessful)result;

            string modversion = loginSuccess.SlotData.GetValueOrDefault("ModVersion").ToString();
            var modversionSplit = modversion.Split(".");
            var pluginVersionSplit = MyPluginInfo.PLUGIN_VERSION.Split(".");
            if (modversionSplit[0] != pluginVersionSplit[0] || modversionSplit[1] != pluginVersionSplit[1])
            {
                Plugin.Logger.LogError($"AP world version {modversion} is not compatible with plugin version {MyPluginInfo.PLUGIN_VERSION}");
                await Session.Socket.DisconnectAsync();
                ConnectionMenu.SetState($"AP Requires Mod v{modversion}", false);

                return false;
            }

            slotData = new SlotData(loginSuccess.SlotData);

            if (slotData.Deathlink)
            {
                deathLinkService = Session.CreateDeathLinkService();
                deathLinkService.EnableDeathLink();
                deathLinkService.OnDeathLinkReceived += (deathLinkObject) =>
                {

                    if (Plugin.EnabledDeathLink())
                    {
                        //killplayer();
                    }
                };
            }

            saveHandler = new SaveHandler(Session.RoomState.Seed, slot);
        }
        else
        {
            return false;
        }

        return true;
    }

    private void ItemReceived(ReceivedItemsHelper helper)
    {
        try
        {
            while (helper.Any())
            {
                var itemIndex = helper.Index;
                var item = helper.DequeueItem();
                Util.RunOnMainThread(() =>
                {
                    ItemHandler.Instance.HandleItem(itemIndex, item);
                });
                
            }
        }
        catch (Exception ex)
        {
            APConsole.Instance.Log($"ItemReceived Error: {ex}");
            throw;
        }
    }

    private void OnMessageReceived(LogMessage message)
    {
        string messageStr;
        if (message.Parts.Any(x => x.Type == MessagePartType.Player) &&
            Plugin.FilterLog != null &&
            Plugin.FilterLog.Value &&
            !message.Parts.Any(x => x.Text.Contains(Session!.Players.GetPlayerName(Session.ConnectionInfo.Slot))))
            return;
        if (message.Parts.Length == 1)
        {
            messageStr = message.Parts[0].Text;
        }
        else
        {
            var builder = new StringBuilder();
            foreach (var part in message.Parts)
            {
                builder.Append($"{part.Text}");
            }

            messageStr = builder.ToString();
        }
        APConsole.Instance.Log(messageStr);
    }

    private void OnError(Exception ex, string message)
    {
        APConsole.Instance.Log($"Socket error: {message} - {ex.Message}");
    }

    private void OnSocketClosed(string reason)
    {
        APConsole.Instance.Log($"Socket closed: {reason}");

    }
    public void SendGoalCompletion()
    {
        Session.SetGoalAchieved();
    }

    public void CompleteLocationChecks(params long[] ids)
    {
        Session.Locations.CompleteLocationChecks(ids);
    }
}
