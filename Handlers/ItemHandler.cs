using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Xml;
using Archipelago.MultiClient.Net.Models;
using JetBrains.Annotations;
using PotionCraft.ScriptableObjects.Talents;
using UnityEngine.InputSystem;
using static PotionCraftAPMod.Data.TalentMapping;
using System.Linq;

namespace PotionCraftAPMod.Handlers;

public class ItemHandler
{
    public static void ProcessNewItem(ItemInfo itemReceived)
    { 
        if (TalentDict.ContainsValue(itemReceived.ItemId))
        {
            var TalKey = TalentDict.FirstOrDefault(x => x.Value == itemReceived.ItemId).Key;
            Plugin.SaveData.TalentCollected.Add(TalKey);
            
           
        }

        

    }
}


/*
 * private void LockButtonIfNecessary()
  {
    int parentTalentLevel = this.GetParentTalentLevel();
    this.Locked = parentTalentLevel != -1 && this.Talent.parentTalentPointsToUnlock > parentTalentLevel;
  }
  */

/*private TalentButtonVisualState GetNormalState()
  {
    return !this.IsEarnedAtLeastOnce() ? TalentButtonVisualState.Unlocked : TalentButtonVisualState.Idle;
  }
  */

/*if(.IsDefined(typeof(TalentEnum), itemReceived.ItemId))
{
     Plugin.SaveData.TalentCollected.Add((TalentEnum)itemReceived.ItemId);
*/ 

