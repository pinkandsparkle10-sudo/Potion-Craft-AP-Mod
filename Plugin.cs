using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using JetBrains.Annotations;
using Newtonsoft.Json;
using PotionCraft.InputSystem;
using PotionCraft.ManagersSystem;
using PotionCraft.ManagersSystem.Goals;
using PotionCraft.ObjectBased.UIElements.Books.GoalsBook;
using PotionCraft.SaveFileSystem;
using PotionCraft.SceneLoader;
using PotionCraft.ScriptableObjects.Ingredient;
using PotionCraft.ScriptableObjects.Talents;
using PotionCraftAPMod.Archipelago;
using PotionCraftAPMod.Handlers;
using PotionCraftAPMod.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using Logger = BepInEx.Logging.Logger;

namespace PotionCraftAPMod;

[BepInPlugin("com.pinkandsparkle10.PotionCraftAPMod", "PotionCraftAPMod", "0.1.0")]
public class Plugin : BaseUnityPlugin
{

    public static new ManualLogSource Logger;
    private static ConfigFile ConfigRef;

    public static ConfigEntry<float> MessageInTime;
    public static ConfigEntry<bool> FilterLog;
    public static ConfigEntry<float> MessageHoldTime;
    public static ConfigEntry<float> MessageOutTime;
    public static ConfigEntry<bool> EnableDebugLogging;

    public static ConfigEntry<Key> ConnectionHotKey;
    public static ConfigEntry<Key> LogToggleKey;
    public static ConfigEntry<Key> HistoryToggleKey;
    //public static ConfigEntry<KeyCode> ConsoleHotkey;
    public static ConfigEntry<bool> doDeathlink;
    public static ConfigEntry<string> LastUsedIP;
    public static ConfigEntry<string> LastUsedPassword;
    public static ConfigEntry<string> LastUsedSlot;

    private void Awake()
    {

        ArchipelagoHandler.Instance = gameObject.AddComponent<ArchipelagoHandler>();
        ItemHandler.Instance = gameObject.AddComponent<ItemHandler>();
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin PotionCraftAPMod is loaded!");
        HarmonyLib.Harmony harmony = new("com.pinkandsparkle10.PotionCraftAPMod");
        harmony.PatchAll(Assembly.GetExecutingAssembly());

        
        //Managers.Npc.
        SceneManager.sceneLoaded += (scene, mode) => this.OnSceneLoad(scene, mode); //TODO
        bindConfig();


    }
    void Start()
    {
        _ = ConnectionMenu.Instance;
        ConnectionMenu.setVisable(false);
    }



    private void Update()
    {
        
        if (Keyboard.current.f5Key.wasPressedThisFrame)
        {
            PotionCraft.ManagersSystem.Player.PlayerManager.AddGoldCommand(10);
        }

    }
    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {

        ;
        Logger.LogInfo($"{scene.name}");
        //if (scene.name.Equals("Main"))
        //{
        //    Plugin.Logger.LogInfo($"does goal manager exist in main? {Managers.Goals != null}");
        //}
        //foreach (Talent talVar in Talent.allTalents)
        //{
            //Logger.LogInfo(talVar.name); 
        //}

        foreach (var ingredient in Ingredient.allIngredients)
        {
            Logger.LogInfo(ingredient.name); 
        }

        

        //Logger.LogInfo($"does goal manager exist? {Managers.Goals != null}");
    }
    public static bool IsGameReady()
    {
        return true;
    }
    public static bool EnabledDeathLink()
    {
        return doDeathlink.Value;
    }

    private void bindConfig()
    {
        ConfigRef = Config;
        EnableDebugLogging = Config.Bind(
                "Logging",
                "EnableDebugLogging",
                false,
                "Enables or disables debug logging in the Archipelago Console."
            );
        FilterLog = Config.Bind(
               "Logging",
               "FilterLog",
               false,
               "Filter the archipelago log to only show messages relevant to you."
           );

        MessageInTime = Config.Bind(
            "Logging",
            "MessageInTime",
            0.25f,
            "How long messages take to animate in."
        );

        MessageHoldTime = Config.Bind(
            "Logging",
            "MessageHoldTime",
            3f,
            "How long messages stay in the log before animating out."
        );

        MessageOutTime = Config.Bind(
            "Logging",
            "MessageOutTime",
            0.5f,
            "How long messages stay in the log before animating out."
        );

        doDeathlink = Config.Bind(
           "GamePlay",
           "Enable Deathlink",
           true,
           "Enable sending and receiving deathlinks. Overrides YAML."
       );

        ConnectionHotKey = Config.Bind(
            "Hotkeys",
            "Toggle Connection Window",
            Key.F2, // Default key
            "Press this key to toggle AP Connection GUI"
        );
        LogToggleKey = Config.Bind(
            "Hotkeys",
            "Toggle AP Console",
            Key.F3, // Default key
            "Press this key to toggle AP Console Output"
        );
        HistoryToggleKey = Config.Bind(
            "Hotkeys",
            "Toggle AP Console History",
            Key.F4, // Default key
            "Press this key to toggle AP Console History"
        );
        LastUsedIP = Config.Bind("Connection", "LastUsedIP", "", "The last server IP entered.");
        LastUsedPassword = Config.Bind("Connection", "LastUsedPassword", "", "The last server password entered.");
        LastUsedSlot = Config.Bind("Connection", "LastUsedSlot", "", "The last player slot name entered.");
    }
}
