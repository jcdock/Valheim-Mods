using HarmonyLib;
using JotunnLib.Entities;
using UnityEngine;

namespace MoreBuildPieces.Prefabs
{
    public class goblinfence : PrefabConfig
    {
        // Create a prefab called "TestCube" with no base
        public goblinfence() : base("goblin-fence", "goblin_fence")
        {

        }

        public override void Register()
        {
            // Add piece component so that we can register this as a piece
            Piece piece = AddPiece(new PieceConfig()
            {
                // The name that shows up in game
                Name = "Goblin Fence",

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

            // Additional piece config if you need here...
        }
    }
}
