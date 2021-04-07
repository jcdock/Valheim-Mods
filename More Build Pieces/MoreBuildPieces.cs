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
            PieceManager.Instance.PieceRegister += registerPieces;
            PrefabManager.Instance.PrefabRegister += registerPrefabs;
            logger.LogInfo("LOADED VERSION 0.0.1!");
        }

        private void registerPrefabs(object sender, EventArgs e)
        {
            PrefabManager.Instance.RegisterPrefab(new goblinwoodwall2m());
            PrefabManager.Instance.RegisterPrefab(new goblinwoodwall1m());
            PrefabManager.Instance.RegisterPrefab(new goblinwoodwall2mribs());
            PrefabManager.Instance.RegisterPrefab(new goblinpole());
            PrefabManager.Instance.RegisterPrefab(new goblinpolesmall());
            PrefabManager.Instance.RegisterPrefab(new goblinroof45d());
            PrefabManager.Instance.RegisterPrefab(new goblinroof45dCorner());
            PrefabManager.Instance.RegisterPrefab(new goblintotempole());
            PrefabManager.Instance.RegisterPrefab(new goblinfence());
            PrefabManager.Instance.RegisterPrefab(new goblinstairs());
            PrefabManager.Instance.RegisterPrefab(new goblinbed());
            PrefabManager.Instance.RegisterPrefab(new goblinstepladder());
        }
        private void registerPieces(object sender, EventArgs e)
        {
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-wood-wall-2m");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-wood-wall-1m");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-wood-wall-2m-ribs");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-pole");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-pole-small");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-roof-45d");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-roof-45dCorner");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-totem-pole");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-fence");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-stairs");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-bed");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-stepladder");

        }
        
        //private void registerObjects(object sender, EventArgs e)
        //{
        //    PrefabManager.Instance.RegisterPrefab(new goblinwoodwall2m());
        //    PrefabManager.Instance.RegisterPrefab(new goblinwoodwall1m());
        //}

    }
}
