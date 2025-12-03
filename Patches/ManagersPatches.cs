using HarmonyLib;
using PotionCraft.ManagersSystem;
using PotionCraft.ObjectBased.UIElements.Books.GoalsBook;
using System;
using System.Collections.Generic;
using System.Text;

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
}
