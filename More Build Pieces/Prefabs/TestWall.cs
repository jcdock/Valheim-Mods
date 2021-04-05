using HarmonyLib;
using JotunnLib.Entities;
using UnityEngine;

namespace RoofPieceMod.Prefabs
{
    public class TestWall : PrefabConfig
    {
        // Create a prefab called "TestCube" with no base
        public TestWall() : base("TestWall", "goblin_woodwall_2m")
        {

        }

        public override void Register()
        {
            // Add piece component so that we can register this as a piece
            Piece piece = AddPiece(new PieceConfig()
            {
                // The name that shows up in game
                Name = "Test Wall",

                // The description that shows up in game
                Description = "A nice test Wall",

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

            // Additional piece config if you need here...
        }
    }
}
