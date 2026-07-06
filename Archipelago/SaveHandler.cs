using System;
using System.Collections.Generic;
using System.Text;
using PotionCraft.ScriptableObjects.Talents;

namespace PotionCraftAPMod.Archipelago;

[Serializable]
public class APSaveData
{
    public int NextExpectedIndex { get; set; }
}
    public class SaveHandler
{
    private string seed;
    private string slot;
    public List<string> TalentCollected = new List<string>();
    APSaveData saveData = new APSaveData();

    public SaveHandler(string seed, string slot)
    {
        this.seed = seed;
        this.slot = slot;
    }
    public APSaveData GetSaveData()
    {
        if (saveData == null)
        {
            throw new Exception("AP SAVE DATA IS NULL");
        }
        return saveData;
    }

    public bool HasTalent(Talent talent)
    {
        //The goal of this function is to check if the talent name is inside TalentCollected
        return TalentCollected.Contains(talent.name);
        throw new NotImplementedException();
    }

}
