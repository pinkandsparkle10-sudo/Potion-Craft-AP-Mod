using System;
using System.Collections.Generic;



namespace PotionCraftAPMod.Archipelago.Mapping;

public class IngredientMapping
{
    public static Dictionary<string, long> IngredientDict = new Dictionary<string, long>
    {
        {"Windbloom", 1}, //herb start
        {"Waterbloom", 2},
        {"Terraria", 3},
        {"Tangleweed", 4},
        {"Lifeleaf", 5},
        {"Firebell", 6},
        {"ThunderThistle", 7},
        {"Icefruit", 8},
        {"HairyBanana", 9},
        {"Goodberry", 10}, 
        {"Goldthorn", 11},
        {"Lavaroot", 12}, 
        {"Featherbloom", 13},
        {"DruidsRosemary", 14},
        {"DreamBeet", 15},
        {"Bloodthorn", 16},
        {"Whirlweed", 17},
        {"Thornstick", 18},
        {"GraspingRoot", 19}, 
        {"Flameweed", 20},
        {"Coldleaf", 21},
        {"Spellbloom", 22},
        {"HealersHeather", 23},
        {"Fluffbloom", 24},
        {"DragonPepper", 25}, 
        {"Boombloom", 26},
        {"TerrorBud", 27},
        {"Mageberry", 28},
        {"EvergreenFern", 29},
        {"DryadsSaddle", 30},
        {"MadMushroom", 31},
        {"Marshroom", 32},
        {"Mudshroom", 33}, 
        {"StinkMushroom", 34},
        {"SulphurShelf", 35}, 
        {"WitchMushroom", 36},
        {"ShadowChanterelle", 37},
        {"Weirdshroom", 38}, 
        {"FoggyParasol", 39}, 
        {"GoblinMushroom", 40}, 
        {"MossShroom" , 41},
        {"PhantomSkirt", 42}, 
        {"Poopshroom", 43},
        {"Watercap", 44},
        {"KrakenMushroom", 45},
        {"LustMushroom", 46}, 
        {"MagmaMorel", 47},
        {"GraveTruffle", 48}, 
        {"RainbowCap", 49},
        {"CloudCrystal", 50}, 
        {"EarthPyrite", 51},
        {"FrostSapphire", 52},
        {"FireCitrine", 53},
        {"BloodRuby", 54},
        {"ArcaneCrystal", 55},
        {"LifeCrystal", 56},
        {"PlagueStibnite", 57},
        {"Fable Bismuth", 58}
        
        
        //GoalsManager Has Chapter and book goal complete for later
    };
}

//TODO use  PotionCraft.ManagersSystem.Managers.Player.Inventory.AddItem(inventoryItem, count); to add a few ingrediants and 1 seed
// use the AP item id Lookup in table above