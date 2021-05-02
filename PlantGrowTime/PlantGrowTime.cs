using BepInEx;
using HarmonyLib;
using UnityEngine;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace PlantGrowTime
{
    using BepInEx;
    using HarmonyLib;
    using UnityEngine;
    using BepInEx.Configuration;
    using BepInEx.Logging;

    namespace PlantGrowTime
    {
        [BepInPlugin("com.github.jcdock.PlantGrowTime", "Plant Grow Time", "1.0.2a")]
        [BepInProcess("valheim.exe")]
        public class PlantGrowTime : BaseUnityPlugin
        {
            private readonly Harmony harmony = new Harmony("Plant Grow Time");
            
            public static ConfigEntry<int> nexusID;
            public static ManualLogSource logger;
            public static ConfigEntry<bool> modEnabled;
            private static ConfigEntry<float> TurnipMultiplier;
            private static ConfigEntry<float> SeedTurnipMultiplier;
            private static ConfigEntry<float> CarrotMultiplier;
            private static ConfigEntry<float> SeedCarrotMultiplier;
            private static ConfigEntry<float> FlaxMultiplier;
            private static ConfigEntry<float> BarleyMultiplier;
            private static ConfigEntry<float> FirMultiplier;
            private static ConfigEntry<float> PineMultiplier;
            private static ConfigEntry<float> BeechMultiplier;
            private static ConfigEntry<float> OtherMultiplier;
            public static ConfigEntry<int> SeedTurnipDrop;
            public static ConfigEntry<int> TurnipDrop;
            public static ConfigEntry<int> SeedCarrotDrop;
            public static ConfigEntry<int> CarrotDrop;
            public static ConfigEntry<int> FlaxDrop;
            public static ConfigEntry<int> BarleyDrop;
            
            

            void Awake()
            {
                logger = Logger;
               
                modEnabled = Config.Bind<bool>("General", "Enabled", true, "Enable this mod (Requires game restart to re-enable)");
                nexusID = Config.Bind<int>("General", "NexusID", 943, "Nexus mod ID for updates (DO NOT MOIDFY THIS VALUE");
                TurnipMultiplier = Config.Bind<float>("General", "Turnip Multiplier", 1f, "Set growtime multiplyer for Turnips");
                SeedTurnipMultiplier = Config.Bind<float>("General", "Seed TurnipMultiplier", 1f, "Set growtime multiplyer for Seed Turnips");
                CarrotMultiplier = Config.Bind<float>("General", "Carrot Multiplier", 1f, "Set growtime multiplyer for Carrots");
                SeedCarrotMultiplier = Config.Bind<float>("General", "Seed CarrotMultiplier", 1f, "Set growtime multiplyer for Seed Carrots");
                FlaxMultiplier = Config.Bind<float>("General", "Flax Multiplier", 1f, "Set growtime multiplyer for Flax");
                BarleyMultiplier = Config.Bind<float>("General", "Barley Multiplier", 1f, "Set growtime multiplyer for Barley");
                FirMultiplier = Config.Bind<float>("General", "Fir Multiplier", 1f, "Set growtime multiplyer for Fir");
                PineMultiplier = Config.Bind<float>("General", "Pine Multiplier", 1f, "Set growtime multiplyer for Pine");
                BeechMultiplier = Config.Bind<float>("General", "Beech Multiplier", 1f, "Set growtime multiplyer for Beech");
                OtherMultiplier = Config.Bind<float>("General", "Other Multiplier", 1f, "Set growtime multiplyer for all else");
                SeedTurnipDrop = Config.Bind<int>("General", "Seed Turnip Drop", 1, "Set amount of seed each Seed Turnip plant drops");
                TurnipDrop = Config.Bind<int>("General", "Turnip Drop", 1, "Set amount of seed each Turnip plant drops");
                SeedCarrotDrop = Config.Bind<int>("General", "Seed Carrot Drop", 1, "Set amount of seed each Seed Carrot plant drops");
                CarrotDrop = Config.Bind<int>("General", "Carrot Drop", 1, "Set amount of seed each Carrot plant drops");
                FlaxDrop = Config.Bind<int>("General", "Flax Drop", 1, "Set amount of seed each Flax plant drops");
                BarleyDrop = Config.Bind<int>("General", "Barley Drop", 1, "Set amount of seed each Barley plant drops");
                if (!modEnabled.Value)
                    return;

                harmony.PatchAll();
                logger.LogInfo("Initialized Plant Time Mod");
               
            }

            void OnDestroy()
            {
                harmony.UnpatchSelf();
            }


            [HarmonyPatch(typeof(Plant), "GetHoverText")]
            static class Plant_GetHoverText_Patch
            {
                static void Postfix(ref Plant __instance, ref string __result)
                {
                    
                    double timeSincePlanted = Traverse.Create(__instance).Method("TimeSincePlanted").GetValue<double>();
                    float growTime = Traverse.Create(__instance).Method("GetGrowTime").GetValue<float>();
                    if (timeSincePlanted < growTime)
                        __result += "\n" + Mathf.RoundToInt((float)timeSincePlanted) + "/" + Mathf.RoundToInt(growTime);
                }
            }

            [HarmonyPatch(typeof(Plant), "Awake")]
            static class Plant_Awake_Patch
            {
                static void Prefix(ref Plant __instance)
                {
                    string name = __instance.m_name;
                    if (name == "$piece_sapling_turnip")
                    {
                        __instance.m_growTime *= TurnipMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;

                    }
                    else if (name == "$piece_sapling_seedturnip")
                    {
                        __instance.m_growTime *= SeedTurnipMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$piece_sapling_carrot")
                    {
                        __instance.m_growTime *= CarrotMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$piece_sapling_seedcarrot")
                    {
                       
                        __instance.m_growTime *= SeedCarrotMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$piece_sapling_barley")
                    {
                        __instance.m_growTime *= BarleyMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$piece_sapling_flax")
                    {
                        __instance.m_growTime *= FlaxMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$prop_fir_sapling")
                    {
                        __instance.m_growTime *= FirMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$prop_pine_sapling")
                    {
                       
                        __instance.m_growTime *= PineMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$prop_beech_sapling")
                    {
                        __instance.m_growTime *= BeechMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else
                    {                
                        __instance.m_growTime *= OtherMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       

                    }
                    logger.LogInfo($"Name: {__instance.m_name} Grow Time: {__instance.m_growTime}");
                }
            }

            [HarmonyPatch(typeof(Pickable), "Awake")]
            static class Pickable_Awake_Patch
            {
                static void Postfix(ref Pickable __instance)
                {
                    
                    string name = __instance.GetHoverName();
                    if (name == "$item_turnipseeds")
                    {
                        __instance.m_amount = SeedTurnipDrop.Value;
                        logger.LogInfo($"Set: {name} to drop: {SeedTurnipDrop.Value}");
                    }
                    if (name == "$item_turnip")
                    {
                        __instance.m_amount = TurnipDrop.Value;
                        logger.LogInfo($"Set: {name} to drop: {TurnipDrop.Value}");
                    }
                    if (name == "$item_carrotseeds")
                    {
                        __instance.m_amount = SeedTurnipDrop.Value;
                        logger.LogInfo($"Set: {name} to drop: {SeedCarrotDrop.Value}");
                    }
                    if (name == "$item_barley")
                    {
                        __instance.m_amount = BarleyDrop.Value;
                        logger.LogInfo($"Set: {name} to drop: {BarleyDrop.Value}");
                    }
                    if (name == "$item_flax")
                    {
                        __instance.m_amount = FlaxDrop.Value;
                        logger.LogInfo($"Set: {name} to drop: {FlaxDrop.Value}");
                    }

                }
            }


        }

    }

}
