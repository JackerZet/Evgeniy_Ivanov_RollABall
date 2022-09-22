using UnityEngine;
using static UnityEngine.Debug;

namespace RollABall.Interactivity
{
    public class WinTheLevel : InteractiveObject
    {
        protected override void Interaction(GameObject gameobject)
        {
            Log("You win!");
        }
    }
}
