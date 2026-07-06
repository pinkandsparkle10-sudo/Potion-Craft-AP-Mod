using HarmonyLib;
using PotionCraft.ManagersSystem;
using PotionCraft.ObjectBased.UIElements.Books.GoalsBook;
using System;
using System.Collections.Generic;
using System.Text;
using Archipelago.MultiClient.Net.Helpers;
using PotionCraftAPMod.Archipelago;
using PotionCraftAPMod.Archipelago.Mapping;
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
            

        }
    }

    public static void OnChapter(ChaptersGroup group, Chapter chapter)
    {
        Plugin.Logger.LogInfo($"Chapter Name {chapter.name} which is in group {group.name} which is {group.GetChapterNumber(chapter)}");
    }

    public static void OnGoalCompleted(PotionCraft.ObjectBased.UIElements.Books.GoalsBook.Goal goal)
    {
        //ArchipelagoHandler.Instance.CompleteLocationChecks(GoalMapping.GoalDict[goal.name]);
        
        Plugin.Logger.LogInfo($"Goal: {goal.customGoalName} {goal.name}");
        
        /*for (int i = 0; i < 10; i++)
        {
            Chapter C = Managers.Goals.goalsBook.GetChapterByGlobalIndex(i);
            foreach (Goal g in C.goals)
            {
                Plugin.Logger.LogInfo(g.name);
            }
        }
        */
    }

    public static void MadeDeal()
    {
        Plugin.Logger.LogInfo("Made Deal");
    }
}

internal class Logger
{
}
//TODO Find talents and find seeds, and find big XP spot, how to remove seeds from merchants
