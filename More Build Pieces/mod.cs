using System;
using UnityEngine;
using BepInEx;
using BepInEx.Logging;
using JotunnLib;
using JotunnLib.ConsoleCommands;
using JotunnLib.Entities;
using JotunnLib.Managers;
using JotunnLib.Utils;
using RoofPieceMod.Prefabs;


namespace RoofPieceMod
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

        }
        private void registerPieces(object sender, EventArgs e)
        {
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-wood-wall-2m");
            PieceManager.Instance.RegisterPiece("Hammer", "goblin-wood-wall-1m");

        }
        
        private void registerObjects(object sender, EventArgs e)
        {
            PrefabManager.Instance.RegisterPrefab(new goblinwoodwall2m());
            PrefabManager.Instance.RegisterPrefab(new goblinwoodwall1m());
        }

    }
}
