using HarmonyLib;
using JotunnLib.Entities;
using UnityEngine;

namespace MoreBuildPieces.Prefabs
{
    public class goblinstairs : PrefabConfig
    {
        // Create a prefab called "TestCube" with no base
        public goblinstairs() : base("goblin-stairs", "goblin_stairs")
        {

        }

        public override void Register()
        {
            // Add piece component so that we can register this as a piece
            // This function is just a util function that will add a piece, and help setup some of the basic requirements of it
            Piece piece = AddPiece(new PieceConfig()
            {
                // The name that shows up in game
                Name = "Goblin Stairs",

                // The description that shows up in game
                Description = "",

                // What items we'll need to build it
                Requirements = new PieceRequirementConfig[]
                {
                new PieceRequirementConfig()
                {
                    // Name of item prefab we need
                    Item = "Wood",
                    
                    // Amount we need
                    Amount = 2
                }
                }
            });
        }
    }
}
