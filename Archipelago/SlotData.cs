using System;
using System.Collections.Generic;
using System.Text;

namespace PotionCraftAPMod.Archipelago;


public class SlotData
{
    public bool Deathlink { get; private set; }
    public bool Sequencial_Talents { get; private set; }
    public SlotData(Dictionary<string, object> slotDict)
    {
        Deathlink = slotDict.GetValueOrDefault("Deathlink").ToString() == "1";
        Sequencial_Talents = true;
    }
}
