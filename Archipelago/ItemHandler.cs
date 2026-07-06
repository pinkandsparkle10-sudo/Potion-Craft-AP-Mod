using Archipelago.MultiClient.Net.Models;
using JetBrains.Annotations;
using PotionCraft.ManagersSystem.Game;
using PotionCraft.ScriptableObjects.Talents;
using PotionCraftAPMod.Archipelago;
using PotionCraftAPMod.UI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.InputSystem;
using static PotionCraftAPMod.Archipelago.Mapping.TalentMapping;

namespace PotionCraftAPMod.Handlers;

public class ItemWrapper
{
    public int Index;
    public ItemInfo Info;

    public ItemWrapper(int index, ItemInfo info)
    {
        Index = index;
        Info = info;
    }
}

public class ItemHandler : MonoBehaviour
{

    private static ItemHandler _instance;
    public static ItemHandler Instance
    {
        get
        {
            if (_instance == null)
                throw new Exception("ItemHandler instance is null. Make sure it is initialized in the scene.");
            return _instance!;
        }
        set { _instance = value; }
    }

    private Queue<ItemWrapper> cachedItems = new Queue<ItemWrapper>();

    public void HandleItem(int index, ItemInfo item, bool save = true)
    {
        if (!Plugin.IsGameReady())
        {
            APConsole.Instance.DebugLog($"Game not ready, caching item: {item.ItemName} (index {index})");
            cachedItems.Enqueue(new ItemWrapper(index, item));
            return;
        }
        try
        {
            if (cachedItems.Count > 0)
            {
                APConsole.Instance.DebugLog($"Processing {cachedItems.Count} cached items...");
                FlushQueue();
            }

            ProcessItem(index, item);

        }
        catch (Exception ex)
        {
            APConsole.Instance.DebugLog($"HandleItem Error: {ex}");
        }
    }


    public void FlushQueue()
    {
        if (!Plugin.IsGameReady())
        {
            return;
        }

        int processedCount = 0;
        while (cachedItems.Count > 0)
        {
            var itemWrapper = cachedItems.Dequeue();
            ProcessItem(itemWrapper.Index, itemWrapper.Info);

            processedCount++;
        }

        APConsole.Instance.DebugLog($"Flushed {processedCount} cached items");
    }


    private void ProcessItem(int index, ItemInfo item)
    {
        if (index < ArchipelagoHandler.Instance.saveHandler.GetSaveData().NextExpectedIndex)
        {
            APConsole.Instance.DebugLog($"Item {index} already processed (current: {ArchipelagoHandler.Instance.saveHandler.GetSaveData().NextExpectedIndex})");
            return;
        }

        ArchipelagoHandler.Instance.saveHandler.GetSaveData().NextExpectedIndex++;

        switch (item.ItemId)
        {
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

