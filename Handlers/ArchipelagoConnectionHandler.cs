using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.MessageLog.Messages;
using Archipelago.MultiClient.Net.Models;
using PotionCraftAPMod.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PotionCraft.ScriptableObjects.Talents;

namespace PotionCraftAPMod.Handlers;

public class ArchipelagoConnectionHandler
{
    private class ItemCache
    {

        public ItemInfo info { get; set; }
        public int index { get; set; }
    }

    public ArchipelagoSession session;
    public SlotData slotData = new SlotData();
    private LoginResult result = null;
    public bool isConnected = false;
    private Queue<ItemCache> cachedItems = new Queue<ItemCache>();

    public void connect(string ip, string password, string slot)
    {
        session = ArchipelagoSessionFactory.CreateSession(ip);

        session.MessageLog.OnMessageReceived += OnMessageReceived;

        session.Items.ItemReceived += OnItemRecieved;

        try
        {
            result = session.TryConnectAndLogin("Potion Craft", slot, ItemsHandlingFlags.AllItems, null, null, null, password, true);
        }
        catch (Exception e)
        {
            result = new LoginFailure(e.GetBaseException().Message);
            Plugin.Logger.LogInfo(e.GetBaseException().Message);
        }

        if (result.Successful)
        {
            isConnected = true;

            session.Socket.SocketClosed += (reason) =>
            {
                isConnected = false;
                Plugin.Logger.LogInfo("Connection Closed");
            };

            var loginSuccess = (LoginSuccessful)result;


            string modversion = loginSuccess.SlotData.GetValueOrDefault("ModVersion").ToString();

            if (!modversion.Equals(MyPluginInfo.PLUGIN_VERSION))
            {
                Plugin.Logger.LogInfo($"AP Expects Mod v{modversion}");
            }
            else
            {
                Plugin.Logger.LogInfo($"Connect with v{modversion}");
            }
        }
        else
        {
            var failure = (LoginFailure)result;
            var errorMessage = $"Failed to Connect to {ip} as {slot}:";
            errorMessage = failure.Errors.Aggregate(errorMessage, (current, error) => current + $"\n    {error}");
            errorMessage = failure.ErrorCodes.Aggregate(errorMessage, (current, error) => current + $"\n    {error}");
            Plugin.Logger.LogInfo(errorMessage);
        }
    }
    static void OnMessageReceived(LogMessage message)
    {
        Plugin.Logger.LogInfo(message.ToString());
    }

    public static void OnItemRecieved(ReceivedItemsHelper receivedItemsHelper)
    {
        //Todo
        //check if we are in game
        //if not, add to a item queue
        ItemHandler.ProcessNewItem(receivedItemsHelper.DequeueItem());
    }

    public void SendGoalCompletion()
    {
        session.SetGoalAchieved();
    }

    public void CompleteLocationChecks(params long[] ids)
    {
        session.Locations.CompleteLocationChecks(ids);
    }
}
