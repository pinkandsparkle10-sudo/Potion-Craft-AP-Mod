
using System;
using System.Collections.Generic;
using PotionCraft.ManagersSystem.Player;
using PotionCraft.ScriptableObjects.Talents;
using static PotionCraftAPMod.Data.TalentMapping;

namespace PotionCraftAPMod.Data;

public class SaveData
{
    public List<string> TalentCollected = new List<string>();
    public int LastPacketReceivedIndex {get; set;}

    public bool HasTalent(Talent talent)
    {
        //The goal of this function is to check if the talent name is inside TalentCollected
        return TalentCollected.Contains(talent.name);
        throw new NotImplementedException();
    }
}





