using System;
using UnityEngine;
using BepInEx;
using BepInEx.Logging;
using JotunnLib;
using JotunnLib.ConsoleCommands;
using JotunnLib.Entities;
using JotunnLib.Managers;
using JotunnLib.Utils;
using MoreBuildPieces.Prefabs;
using Shared;
using HarmonyLib;


namespace MoreBuildPieces
{
    
    [BepInPlugin("JcDock.MoreBuildPieces", "More Build Pieces", "0.0.1")]
    [BepInDependency(JotunnLib.JotunnLib.ModGuid)]

    class mod : BaseUnityPlugin
    {
        public static ManualLogSource logger;
        private void Awake()
        {
            logger = Logger;
            PrefabManager.Instance.PrefabRegister += registerPrefabs;
            PieceManager.Instance.PieceRegister += registerPieces;
            logger.LogInfo("LOADED VERSION 0.0.1!");
        }

        private void registerPrefabs(object sender, EventArgs e)
        {
           
         var bundle = AssetBundleHelper.GetAssetBundleFromResources("mbp_goblin");
           


            // when this is fixed, the call should be:
            // PrefabManager.Instance.RegisterPrefab(name, "Name");
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_fence.prefab"), "mbp_goblin_fence" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_pole.prefab"), "mbp_goblin_pole" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_roof_45d.prefab"), "mbp_goblin_roof_45d" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_roof_45d_corner.prefab"), "mbp_goblin_roof_45d_corner" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_roof_45d_cap.prefab"), "mbp_goblin_roof_45d_cap" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_stairs.prefab"), "mbp_goblin_stairs" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_totempole.prefab"), "mbp_goblin_totempole" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_woodwall_1m.prefab"), "mbp_goblin_woodwall_1m" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_woodwall_2m.prefab"), "mbp_goblin_woodwall_2m" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mbp_goblin_woodwall_2m_ribs.prefab"), "mbp_goblin_woodwall_2m_ribs" });
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/mbp/mpb_goblin_pole_small.prefab"), "mpb_goblin_pole_small" });


        }
        private void registerPieces(object sender, EventArgs e)
        {
            PieceManager.Instance.RegisterPiece("Hammer", "mbp_goblin_fence");
            PieceManager.Instance.RegisterPiece("Hammer", "mbp_goblin_pole");
            PieceManager.Instance.RegisterPiece("Hammer", "mbp_goblin_roof_45d");
            PieceManager.Instance.RegisterPiece("Hammer", "mbp_goblin_roof_45d_corner");
            PieceManager.Instance.RegisterPiece("Hammer", "mbp_goblin_stairs");
            PieceManager.Instance.RegisterPiece("Hammer", "mbp_goblin_woodwall_1m");
            PieceManager.Instance.RegisterPiece("Hammer", "mbp_goblin_woodwall_2m");
            PieceManager.Instance.RegisterPiece("Hammer", "mbp_goblin_woodwall_2m_ribs");
            PieceManager.Instance.RegisterPiece("Hammer", "mpb_goblin_pole_small");
            PieceManager.Instance.RegisterPiece("Hammer", "mbp_goblin_totempole");
            
        }



    }
}
