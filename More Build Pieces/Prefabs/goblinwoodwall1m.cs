using HarmonyLib;
using JotunnLib.Entities;
using UnityEngine;

namespace MoreBuildPieces.Prefabs
{
    public class goblinwoodwall1m : PrefabConfig
    {
        // Create a prefab called "TestCube" with no base
        public goblinwoodwall1m() : base("goblin-wood-wall-1m", "goblin_woodwall_1m")
        {

        }

        public override void Register()
        {
            // Add piece component so that we can register this as a piece
            Piece piece = AddPiece(new PieceConfig()
            {
                // The name that shows up in game
                Name = "Goblin Wooden Wall 1M",

                // The description that shows up in game
                Description = null,

                // What items we'll need to build it
                Requirements = new PieceRequirementConfig[]
                {
                    new PieceRequirementConfig()
                    {
                        // Name of item prefab we need
                        Item = "Wood",
                        
                        // Amount we need
                        Amount = 1
                    }
                }
            });
           
           
        }
    }
}
