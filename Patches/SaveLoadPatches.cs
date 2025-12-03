using HarmonyLib;
using PotionCraft.ManagersSystem.SaveLoad;
using System;
using System.Collections.Generic;
using System.Text;

namespace PotionCraftAPMod.Patches;

[HarmonyPatch(typeof(SaveLoadManager))]
public class SaveLoadPatches
{
    [HarmonyPatch("MethodNameHere")]
    [HarmonyPrefix]
    static bool PreFix()
    {
        if (true)
        {
            //InteractionPlayerController
            return true;
        }
        return false;
    }
}
