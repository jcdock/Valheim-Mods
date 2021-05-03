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
        [BepInPlugin("com.github.jcdock.PlantGrowTime", "Plant Grow Time", "1.2.1")]
        [BepInProcess("valheim.exe")]
        public class PlantGrowTime : BaseUnityPlugin
        {
            private readonly Harmony harmony = new Harmony("Plant Grow Time");
            
            public static ConfigEntry<int> nexusID;
            public static ManualLogSource logger;
            public static ConfigEntry<bool> modEnabled;
            public static ConfigEntry<bool> dropRateEnabled;
            public static ConfigEntry<bool> GrowRateEnabled;
            private static ConfigEntry<float> TurnipGrowtime;
            private static ConfigEntry<float> SeedTurnipGrowtime;
            private static ConfigEntry<float> CarrotGrowtime;
            private static ConfigEntry<float> SeedCarrotGrowtime;
            private static ConfigEntry<float> FlaxGrowtime;
            private static ConfigEntry<float> BarleyGrowtime;
            private static ConfigEntry<float> FirGrowTime;
            private static ConfigEntry<float> PineGrowTime;
            private static ConfigEntry<float> BeechGrowTime;
            private static ConfigEntry<float> OtherGrowTime;
            public static ConfigEntry<int> SeedTurnipDrop;
            public static ConfigEntry<int> TurnipDrop;
            public static ConfigEntry<int> SeedCarrotDrop;
            public static ConfigEntry<int> CarrotDrop;
            public static ConfigEntry<int> FlaxDrop;
            public static ConfigEntry<int> BarleyDrop;
            
            

            void Awake()
            {
                logger = Logger;
               
                modEnabled = Config.Bind<bool>("General", "1Mod Enabled", true, "Enable this mod (Requires game restart to re-enable)");
                GrowRateEnabled = Config.Bind<bool>("General", "1Grow Rate Change Enabled", true, "Enable Grow Rate Change");
                dropRateEnabled = Config.Bind<bool>("General", "1Drop Rate Change Enabled", true, "Enable Drop Rate Change");
                nexusID = Config.Bind<int>("General", "NexusID", 943, "Nexus mod ID for updates (DO NOT MOIDFY THIS VALUE)");
                TurnipGrowtime = Config.Bind<float>("General", "Turnip GrowTime", 600f, "Set growtime in seconds for Turnips");
                SeedTurnipGrowtime = Config.Bind<float>("General", "Seed TurnipGrowtime", 600f, "Set growtime in seconds for Seed Turnips");
                CarrotGrowtime = Config.Bind<float>("General", "Carrot GrowTime", 600f, "Set growtime in seconds for Carrots");
                SeedCarrotGrowtime = Config.Bind<float>("General", "Seed CarrotGrowtime", 600f, "Set growtime in seconds for Seed Carrots");
                FlaxGrowtime = Config.Bind<float>("General", "Flax GrowTime", 600f, "Set growtime in seconds for Flax");
                BarleyGrowtime = Config.Bind<float>("General", "Barley GrowTime", 600f, "Set growtime in seconds for Barley");
                FirGrowTime = Config.Bind<float>("General", "Fir GrowTime", 1200f, "Set growtime in seconds for Fir");
                PineGrowTime = Config.Bind<float>("General", "Pine GrowTime", 1200f, "Set growtime in seconds for Pine");
                BeechGrowTime = Config.Bind<float>("General", "Beech GrowTime", 1200f, "Set growtime in seconds for Beech");
                OtherGrowTime = Config.Bind<float>("General", "Other GrowTime", 600f, "Set growtime in seconds for all else");
                SeedTurnipDrop = Config.Bind<int>("General", "Seed Turnip Drop", 3, "Set amount of seed each Seed Turnip plant drops");
                TurnipDrop = Config.Bind<int>("General", "Turnip Drop", 2, "Set amount of seed each Turnip plant drops");
                SeedCarrotDrop = Config.Bind<int>("General", "Seed Carrot Drop", 3, "Set amount of seed each Seed Carrot plant drops");
                CarrotDrop = Config.Bind<int>("General", "Carrot Drop", 2, "Set amount of seed each Carrot plant drops");
                FlaxDrop = Config.Bind<int>("General", "Flax Drop", 2, "Set amount of seed each Flax plant drops");
                BarleyDrop = Config.Bind<int>("General", "Barley Drop", 2, "Set amount of seed each Barley plant drops");
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
                    if (!GrowRateEnabled.Value)
                        return;
                    string name = __instance.m_name;
                    if (name == "$piece_sapling_turnip")
                    {
                        __instance.m_growTime = TurnipGrowtime.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;

                    }
                    else if (name == "$piece_sapling_seedturnip")
                    {
                        __instance.m_growTime = SeedTurnipGrowtime.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$piece_sapling_carrot")
                    {
                        __instance.m_growTime = CarrotGrowtime.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$piece_sapling_seedcarrot")
                    {
                       
                        __instance.m_growTime = SeedCarrotGrowtime.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$piece_sapling_barley")
                    {
                        __instance.m_growTime = BarleyGrowtime.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$piece_sapling_flax")
                    {
                        __instance.m_growTime = FlaxGrowtime.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$prop_fir_sapling")
                    {
                        __instance.m_growTime = FirGrowTime.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$prop_pine_sapling")
                    {
                       
                        __instance.m_growTime = PineGrowTime.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else if (name == "$prop_beech_sapling")
                    {
                        __instance.m_growTime = BeechGrowTime.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                       
                    }
                    else
                    {                
                        __instance.m_growTime = OtherGrowTime.Value;
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
                    if (!dropRateEnabled.Value)
                        return;
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
