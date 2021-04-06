using HarmonyLib;
using JotunnLib.Entities;
using UnityEngine;

namespace RoofPieceMod.Prefabs
{
    public class goblinroof45d : PrefabConfig
    {
        // Create a prefab called "TestCube" with no base
        public goblinroof45d() : base("goblin-roof-45d", "goblin_roof_45d")
        {

        }

        public override void Register()
        {
            // Add piece component so that we can register this as a piece
            Piece piece = AddPiece(new PieceConfig()
            {
                // The name that shows up in game
                Name = "Goblin Roof 45°",

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
                        Amount = 2
                    }
                }
            });
           
            }
        }
    }
}
