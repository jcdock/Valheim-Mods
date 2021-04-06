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
        [BepInPlugin("com.github.jcdock.PlantGrowTime", "Plant Grow Time", "1.0.0")]
        [BepInProcess("valheim.exe")]
        public class MyMod : BaseUnityPlugin
        {
            private readonly Harmony harmony = new Harmony("Plant Grow Time");
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
           // public static ConfigEntry<int> nexusID;
            public static ManualLogSource logger;
            

            void Awake()
            {
                logger = Logger;
               
                modEnabled = Config.Bind<bool>("General", "Enabled", true, "Enable this mod");
                TurnipMultiplier = Config.Bind<float>("General", "TurnipMultiplier", 0.5f, "Set growtime multiplyer for Turnips");
                SeedTurnipMultiplier = Config.Bind<float>("General", "SeedTurnipMultiplier", 0.5f, "Set growtime multiplyer for Seed Turnips");
                CarrotMultiplier = Config.Bind<float>("General", "CarrotMultiplier", 0.5f, "Set growtime multiplyer for Carrots");
                SeedCarrotMultiplier = Config.Bind<float>("General", "SeedCarrotMultiplier", 0.5f, "Set growtime multiplyer for Seed Carrots");
                FlaxMultiplier = Config.Bind<float>("General", "FlaxMultiplier", 0.5f, "Set growtime multiplyer for Flax");
                BarleyMultiplier = Config.Bind<float>("General", "BarleyMultiplier", 0.5f, "Set growtime multiplyer for Barley");
                FirMultiplier = Config.Bind<float>("General", "FirMultiplier", 0.5f, "Set growtime multiplyer for Fir");
                PineMultiplier = Config.Bind<float>("General", "PineMultiplier", 0.5f, "Set growtime multiplyer for Pine");
                BeechMultiplier = Config.Bind<float>("General", "BeechMultiplier", 0.5f, "Set growtime multiplyer for Beech");
                OtherMultiplier = Config.Bind<float>("General", "OtherMultiplier", 0.5f, "Set growtime multiplyer for all else");
               // nexusID = Config.Bind<int>("General", "NexusID", 853, "Nexus mod ID for updates");
                
                if (!modEnabled.Value)
                {
                    return;
                }
                else
                {
                    harmony.PatchAll();
                    logger.LogInfo("Initialized Plant Time Mod");
                }
            }

            void OnDestroy()
            {
                harmony.UnpatchSelf();
            }

            [HarmonyPatch(typeof(Plant), "Awake")]
            static class Plant_Awake_Patch
            {
                static void Postfix(ref Plant __instance)
                {
                    string name = __instance.m_name;
                    if (name == "$piece_sapling_turnip")
                    {
                        logger.LogInfo("TURNIPS!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= TurnipMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {TurnipMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                    else if (name == "$piece_sapling_seedturnip")
                    {
                        logger.LogInfo("SEED TURNIPS!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= SeedTurnipMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {SeedTurnipMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                    else if (name == "$piece_sapling_carrot")
                    {
                        logger.LogInfo("Carrots!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= CarrotMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {CarrotMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                    else if (name == "$piece_sapling_seedcarrot")
                    {
                        logger.LogInfo("SEED carrots!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= SeedCarrotMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {SeedCarrotMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                    else if (name == "$piece_sapling_barley")
                    {
                        logger.LogInfo("Barley!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= BarleyMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {BarleyMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                    else if (name == "$piece_sapling_flax")
                    {
                        logger.LogInfo("Flax!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= FlaxMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {FlaxMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                    else if (name == "$prop_fir_sapling")
                    {
                        logger.LogInfo("Fir!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= FirMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {FirMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                    else if (name == "$prop_pine_sapling")
                    {
                        logger.LogInfo("Pine!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= PineMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {PineMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                    else if (name == "$prop_beech_sapling")
                    {
                        logger.LogInfo("Beech!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= BeechMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {BeechMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                    else
                    {
                        logger.LogInfo("OTHER!!!!!");
                        logger.LogInfo($"Name:  {__instance.m_name}");
                        logger.LogInfo($"growtime 1: {__instance.m_growTime} \n Max growtime 1: {__instance.m_growTimeMax} ");
                        __instance.m_growTime *= OtherMultiplier.Value;
                        __instance.m_growTimeMax = __instance.m_growTime;
                        logger.LogInfo($"Using Multiplier: {TurnipMultiplier.Value}");
                        logger.LogInfo($"growtime 2: {__instance.m_growTime} \n Max growtime 2: {__instance.m_growTimeMax} ");
                    }
                }
            }
        }
    }

}
