using System.Collections.Generic;


namespace PotionCraftAPMod.Archipelago.Mapping;


public class GoalMapping
{
    public static Dictionary<string, long> GoalDict = new Dictionary<string, long>
    {
    { "PrepareIngredient", 1 },                  // Grab an ingredient from Inventory
    { "GrindIngredient", 2 },                       // Grind an Ingredient (assuming ID should be 2)
    { "PutIngredientToCauldron", 3 },
    { "MoveIndicator", 4 },                         // Stir Cauldron
    { "AddPotionEffect", 5 },                       // Heat Cauldron
    { "CreatePotion", 6 },
    { "VisitGarden", 7 },
    { "GatherIngredient", 8 },
    { "VisitMeetingRoom", 9 },                      // Go to Shop
    { "SellPotion", 10 },
    { "BuySomething", 11 },                         // Buy From Merchant
    { "CollectXpVerySmallSize", 12 },               // Collect Small Experience
    { "LearnTalent", 13 },
    { "VisitCellar", 14 },                          // Go to Basement
    { "VisitBedroom", 15 },
    { "StartNewDay", 16 },
    { "ReachPopularityTier2", 17 },
    { "CraftPotionWithHealingEffect", 18 },
    { "CraftPotionWithPoisonEffect", 19 },
    { "CraftPotionWithFireEffect", 20 },
    { "CraftPotionWithFrostEffect", 21 },

    { "PourBaseInCauldron", 22 },                   // Use Water
    { "CraftPotion2Tier", 23 },
    { "CraftPotionWith2Effects", 24 },
    { "SaveRecipe", 25 },
    { "CreatePotionFromRecipeBook", 26 },
    { "HaggleAndGetBetterDeal", 27 },
    { "ReachPopularityTier4", 28 },
    { "CollectXpSmallSize", 29 },
    { "CraftPotionWithExplosionEffect", 30 },
    { "CraftPotionWithWildGrowthEffect", 31 },
    { "CraftPotionWithStrengthEffect", 32 },
    { "CraftPotionWithDexterityEffect", 33 },
    { "CraftPotionWithSwiftnessEffect", 34 },

    { "ReachAlchemyMachineUpgrade1", 35 },          // Repair the Alchemy Machine
    { "BuyRecipeBookPage", 36 },
    { "CraftPotion3Tier", 37 },
    { "CraftPotionWith3Effects", 38 },
    { "CollectXpMediumSize", 39 },
    { "ReachPopularityTier5", 40 },
    { "CreateCustomPotion", 41 },
    { "CraftPotionWithLightningEffect", 42 },
    { "CraftPotionWithManaEffect", 43 },
    { "CraftPotionWithStoneSkinEffect", 44 },
    { "CraftPotionWithSleepEffect", 45 },
    { "CraftPotionWithLightEffect", 46 },

    { "CreateLegendarySubstanceNigredo", 47 },
    { "CraftPotionWith4Effects", 48 },
    { "ReachPopularityTier6", 49 },
    { "CollectXpBigSize", 50 },
    { "CraftPotionWithCharmEffect", 51 },
    { "CraftPotionWithSlownessEffect", 52 },
    { "CraftPotionWithRageEffect", 53 },
    { "CraftPotionWithMagicalVisionEffect", 54 },

    { "ReachAlchemyMachineUpgrade2", 55 },          // Buy Basic Alchemy Machine Upgrade
    { "BuyRecipeVoidSalt", 56 },
    { "CreateLegendarySubstanceVoid Salt Pile", 57 },
    { "CraftPotionWith5Effects", 58 },
    { "CollectXpVeryBigSize", 59 },
    { "ReachPopularityTier7", 60 },
    { "CraftPotionWithAcidEffect", 61 },
    { "CraftPotionWithLibidoEffect", 62 },
    { "CraftPotionWithInvisibilityEffect", 63 },
    { "CraftPotionWithLevitationEffect", 64 },
    { "CraftPotionWithNecromancyEffect", 65 },

    { "BuyOilBase", 66 },
    { "CreateLegendarySubstanceAlbedo", 67 },
    { "ReachPopularityTier8", 68 },
    { "CraftPotionWithPoisonProtectionEffect", 69 },
    { "CraftPotionWithLightningProtectionEffect", 70 },
    { "CraftPotionWithFireProtectionEffect", 71 },
    { "CraftPotionWithFrostProtectionEffect", 72 },
    { "CraftPotionWithGluingEffect", 73 },
    { "CraftPotionWithSlipperinessEffect", 74 },
    { "CraftPotionWithStenchEffect", 75 },

    { "ReachAlchemyMachineUpgrade3", 76 },          // Buy Advanced Alchemy Machine
    { "BuyRecipeMoonSalt", 77 },
    { "CreateLegendarySubstanceMoon Salt Pile", 78 },
    { "ReachPopularityTier9", 79 },
    { "CraftPotionWithAcidProtectionEffect", 80 },
    { "CraftPotionWithAntiMagicEffect", 81 },
    { "CraftPotionWithShrinkingEffect", 82 },
    { "CraftPotionWithEnlargementEffect", 83 },
    { "CraftPotionWithRejuvenationEffect", 84 },

    { "CreateLegendarySubstanceCitrinitas", 85 },
    { "ReachPopularityTier10", 86 },
    { "CraftPotionWithInspirationEffect", 87 },
    { "CraftPotionWithFragranceEffect", 88 },
    { "CraftPotionWithFearEffect", 89 },

    { "BuyRecipeSunSalt", 90 },
    { "CreateLegendarySubstanceSun Salt Pile", 91 },
    { "CreateLegendarySubstanceRubedo", 92 },
    { "ReachPopularityTier12", 93 },
    { "CraftPotionWithHallucinationsEffect", 94 },
    { "CraftPotionWithLuckEffect", 95 },
    { "CraftPotionWithCurseEffect", 96 },

    { "CreateLegendarySubstancePhilosophersStone", 97 },
    { "BuyRecipeLifeSalt", 98 },
    { "CreateLegendarySubstanceLife Salt Pile", 99 },
    { "BuyRecipePhilosophersSalt", 100 },
    { "CreateLegendarySubstancePhilosopher's Salt Pile", 101 },
    { "ReachPopularityTier15", 102 },
    };
}