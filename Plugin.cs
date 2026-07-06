using System;
using System.Collections;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JetBrains.Annotations;
using PotionCraft.InputSystem;
using PotionCraft.ManagersSystem;
using PotionCraft.ManagersSystem.Goals;
using PotionCraft.ObjectBased.UIElements.Books.GoalsBook;
using PotionCraft.ScriptableObjects.Ingredient;
using System.Reflection;
using PotionCraftAPMod.Data;
using PotionCraftAPMod.Handlers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using PotionCraft.ScriptableObjects.Talents;
using Logger = BepInEx.Logging.Logger;

namespace PotionCraftAPMod;

[BepInPlugin("com.pinkandsparkle10.PotionCraftAPMod", "PotionCraftAPMod", "0.1.0")]
public class Plugin : BaseUnityPlugin
{
    public static ArchipelagoConnectionHandler ApConnectHandler;
    public static new ManualLogSource Logger;
    public static SaveData SaveData = new SaveData();
    public static SlotData SlotData = new SlotData();

    private void Awake()
    {
        ApConnectHandler = new ArchipelagoConnectionHandler();
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin PotionCraftAPMod is loaded!");
        HarmonyLib.Harmony harmony = new("com.pinkandsparkle10.PotionCraftAPMod");
        harmony.PatchAll(Assembly.GetExecutingAssembly());

        
        //Managers.Npc.
        SceneManager.sceneLoaded += (scene, mode) => this.OnSceneLoad(scene, mode); //TODO
        
        //testing remove
        SlotData.Sequencial_Talents = false;

    }

   

    private void Update()
    {
        if (Keyboard.current.f6Key.wasPressedThisFrame)
        {
            PotionCraft.ManagersSystem.Player.PlayerManager.AddGoldCommand(10);
        }

    }
    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
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
    
    
    
    //BIG NOTE TO DOWNLOAD MOD MOVE POTIONCRAFTAPMOD.DLL to (bepin -> plugins folder)
}
