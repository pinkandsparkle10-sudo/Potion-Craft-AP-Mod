using System;
using System.Collections.Generic;
using PotionCraft.ScriptableObjects.Talents;

namespace PotionCraftAPMod.Archipelago.Mapping;

public class TalentMapping
{
    public static Dictionary<string, long> TalentDict = new Dictionary<string, long>
    {
        { "TalentTradeTrading", 100 }, //trading start
        { "TalentTradePotionOfferAttemptsCount", 101 },
        { "TalentTradeDecreaseRejectionPenalty", 102 },
        { "TalentTradeBetterPricesForEachCustomer", 103 },
        { "TalentTradeCustomersQueueSize", 104 },
        { "TalentTradePerfectHaggling", 105 },
        { "TalentTradeHagglingDifficulty4", 106 },
        { "TalentTradeHagglingDifficulty5", 107 },
        { "TalentTradeSlowHaggling", 108 },
        { "TalentTradeDecreaseScalesMissPenalty", 109 },
        { "TalentTradeSlowScalesTilting", 110 },
        { "TalentTradeGoodPotionSeller", 111 },
        { "TalentTradeSimplePotionSeller", 112 },
        { "TalentTradeMerchantsPotionPrice", 113 },
        { "TalentTradeMerchantsAssortmentSize", 114 },
        { "TalentTradeIncreasedDiscountChance", 115 },
        { "TalentTradeReducedMarkupChance", 116 },
        { "TalentTradeMerchantsGoldAmount", 117 },
        { "TalentTradePotionPriceEndless", 118 },
        { "TalentTradePotionPrice", 154 },
        { "TalentTradeBestPotionSeller", 155 }, // trading end
        { "TalentGardeningFertilizingPlants", 119 }, //gardening start
        { "TalentGardeningThoroughCareHerbs", 120 },
        { "TalentGardeningThoroughCareMushrooms", 121 },
        { "TalentGardeningThoroughCareCrystals", 122 },
        { "TalentGardeningHerbHarvesting", 123 },
        { "TalentGardeningHerbHarvestingPlus", 124 },
        { "TalentGardeningMushroomHarvesting", 125 },
        { "TalentGardeningMushroomHarvestingPlus", 126 },
        { "TalentGardeningCrystalHarvesting", 127 },
        { "TalentGardeningCrystalHarvestingPlus", 128 },
        { "TalentGardeningGoldDigger", 129 },
        { "TalentGardeningGoldDiggerPlus", 130 },
        { "TalentGardeningPlantingHerbs", 131 },
        { "TalentGardeningReplantingHerbs", 132 },
        { "TalentGardeningSeedHarvestingHerbs", 133 },
        { "TalentGardeningFastGrowthHerbs", 134 },
        { "TalentGardeningPlantingUnderWater", 135 },
        { "TalentGardeningPlantingCaveHerbs", 136 },
        { "TalentGardeningPlantingMushrooms", 137 },
        { "TalentGardeningReplantingMushrooms", 138 },
        { "TalentGardeningSeedHarvestingMushrooms", 139 },
        { "TalentGardeningFastGrowthMushrooms", 140 },
        { "TalentGardeningPlantingNearRoots", 141 },
        { "TalentGardeningPlantingCrystal", 142 },
        { "TalentGardeningReplantingCrystals", 143 },
        { "TalentGardeningSeedHarvestingCrystals", 144 },
        { "TalentGardeningFastGrowthCrystals", 145 },
        { "TalentGardeningFertilizingCrystals", 146 }, //gardening end
        { "TalentAlchemyBatchPotionBrewing", 147 }, //alchemy start
        { "TalentAlchemyAlchemicalPractice", 148 },
        { "TalentAlchemyGoldExperienceBonuses", 149 },
        { "TalentAlchemyAlchemicalMapVisionRadius", 150 },
        { "TalentAlchemyIngredientsRefund", 151 },
        { "TalentAlchemySaltsRefund", 152 },
        { "TalentAlchemyIncreaseCraftedSaltAmount", 153 }, //alchemy end
        { "Map Water", 156 }, //Not sure if we need last 2 but its on list
        { "Talents", 157 },



    };

}

