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
            PrefabManager.Instance.RegisterPrefab(new goblinwoodwall2m());
            //PrefabManager.Instance.RegisterPrefab(new goblinwoodwall1m());
            //PrefabManager.Instance.RegisterPrefab(new goblinwoodwall2mribs());
            //PrefabManager.Instance.RegisterPrefab(new goblinpole());
            //PrefabManager.Instance.RegisterPrefab(new goblinpolesmall());
            //PrefabManager.Instance.RegisterPrefab(new goblinroof45d());
            //PrefabManager.Instance.RegisterPrefab(new goblinroof45dCorner());
            //PrefabManager.Instance.RegisterPrefab(new goblintotempole());
            //PrefabManager.Instance.RegisterPrefab(new goblinfence());
            //  PrefabManager.Instance.RegisterPrefab(new goblinbed());
            /* Disabled for now, cant figure out why it wont work
            PrefabManager.Instance.RegisterPrefab(new goblinstairs());
            PrefabManager.Instance.RegisterPrefab(new goblinstepladder());
            */
           
            var bundle = AssetBundleHelper.GetAssetBundleFromResources("mbp_goblin");
          //  var teststairs = bundle.LoadAsset<GameObject>("Assets/CustomAssets/Prefabs/teststairs.prefab");


            // when this is fixed, the call should be:
            // PrefabManager.Instance.RegisterPrefab(teststairs, "TestStairs");
            AccessTools.Method(typeof(PrefabManager), "RegisterPrefab", new Type[] { typeof(GameObject), typeof(string) }).Invoke(PrefabManager.Instance, new object[] { bundle.LoadAsset<GameObject>("Assets/CustomAssets/Prefabs/teststairs.prefab"), "Teststairs" });

            

        }
        private void registerPieces(object sender, EventArgs e)
        {
            PieceManager.Instance.RegisterPiece("Hammer", "Teststairs");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-wood-wall-2m");
            //PieceManager.Instance.RegisterPiece("Hammer", "goblin-wood-wall-1m");
            //PieceManager.Instance.RegisterPiece("Hammer", "goblin-wood-wall-2m-ribs");
            //PieceManager.Instance.RegisterPiece("Hammer", "goblin-pole");
            //PieceManager.Instance.RegisterPiece("Hammer", "goblin-pole-small");
            //PieceManager.Instance.RegisterPiece("Hammer", "goblin-roof-45d");
            //PieceManager.Instance.RegisterPiece("Hammer", "goblin-roof-45d-corner");
            //PieceManager.Instance.RegisterPiece("Hammer", "goblin-totempole");
            //PieceManager.Instance.RegisterPiece("Hammer", "goblin-fence");
          //  PieceManager.Instance.RegisterPiece("Hammer", "goblin-bed");
            /* Disabled for now, cant figure out why it wont work
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-stepladder");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-stairs");
           */
        }



    }
}
