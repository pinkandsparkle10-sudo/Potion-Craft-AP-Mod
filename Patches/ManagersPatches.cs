using HarmonyLib;
using PotionCraft.ManagersSystem;
using PotionCraft.ObjectBased.UIElements.Books.GoalsBook;
using System;
using System.Collections.Generic;
using System.Text;
using Archipelago.MultiClient.Net.Helpers;
using PotionCraftAPMod.Handlers;

namespace PotionCraftAPMod.Patches;


[HarmonyPatch(typeof(Managers))]
public class ManagersPatches
{
    [HarmonyPatch("TryToInit")]
    [HarmonyPostfix]
    static void PostFix(bool forced)
    {
        if (Managers.Goals != null)
        {
            Managers.Goals.onChapterCompleted.AddListener(OnChapter);
            Managers.Goals.onGoalCompleted.AddListener(OnGoalCompleted);
            Plugin.Logger.LogInfo("Run Listeners");
            Managers.Trade.onMakeDeal.AddListener(MadeDeal);
            ArchipelagoConnectionHandler.session.Items.ItemReceived.AddListener(ReceivedItem); 
            //Fyre I give up, Where are the locations?

        }
    }

    public static void OnChapter(ChaptersGroup group, Chapter chapter)
    {
        Plugin.Logger.LogInfo($"Chapter Name {chapter.name} which is in group {group.name} which is {group.GetChapterNumber(chapter)}");
    }

    public static void OnGoalCompleted(PotionCraft.ObjectBased.UIElements.Books.GoalsBook.Goal goal)
    {
        Plugin.Logger.LogInfo($"Goal: {goal.customGoalName} {goal.name}");
    }

    public static void MadeDeal()
    {
        Plugin.Logger.LogInfo("Made Deal");
    }

    private static void ReceivedItem()
    {
        Plugin.Logger.LogInfo("Item Received");
    }
}
