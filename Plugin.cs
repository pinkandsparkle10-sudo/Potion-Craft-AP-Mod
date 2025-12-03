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
using UnityEngine;
using UnityEngine.InputSystem;

namespace PotionCraftAPMod;

[BepInPlugin("com.pinkandsparkle10.PotionCraftAPMod", "PotionCraftAPMod", "0.1.0")]
public class Plugin : BaseUnityPlugin
{
    public static new ManualLogSource Logger;
        
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin PotionCraftAPMod is loaded!");
        HarmonyLib.Harmony harmony = new("com.pinkandsparkle10.PotionCraftAPMod");
        //harmony.PatchAll(Assembly.GetExecutingAssembly());

        Managers.Goals.onChapterCompleted.AddListener(OnChapter);
        //Managers.Npc.

    }

    public void OnChapter(ChaptersGroup group, Chapter chapter)
    {
        //send chapter location
    }

    private void Update()
    {
        if (Keyboard.current.f6Key.wasPressedThisFrame)
        {
            PotionCraft.ManagersSystem.Player.PlayerManager.AddGoldCommand(10);
        }
            
    }
  
}
