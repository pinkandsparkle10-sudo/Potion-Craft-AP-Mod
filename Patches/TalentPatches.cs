using System;
using System.Collections.Generic;
using BepInEx;
using HarmonyLib;
using PotionCraft.ScriptableObjects.Talents;
using PotionCraftAPMod.Data;
using TalentsWindowSystem.TalentButtonItem;

namespace PotionCraftAPMod.Patches;
//TODO Function to lock all talents, Find all functions that unlock a talent

[HarmonyPatch(typeof(TalentButton))]
public class TalentPatches
{
    [HarmonyPatch("LockButtonIfNecessary")]
    [HarmonyPrefix]
    static bool PreFix(TalentButton __instance)
    {
        int parentTalentLevel = __instance.GetParentTalentLevel();
        __instance.Locked = ((parentTalentLevel != -1 || !Plugin.SlotData.Sequencial_Talents) && 
                            __instance.Talent.parentTalentPointsToUnlock > parentTalentLevel) ||
                            !Plugin.SaveData.HasTalent(__instance.Talent);
        __instance.UpdateLockedState();
        Plugin.Logger.LogInfo(__instance.Talent.name);
        return false;
    }
}

