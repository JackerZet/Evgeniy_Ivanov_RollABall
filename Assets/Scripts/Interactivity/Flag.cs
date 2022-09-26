using RollABall.Player;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class Flag : InteractiveObject
    {
        protected override void Interaction(GameObject gameobject)
        {
            if (gameobject.TryGetComponent(out PlayerBall player))
            {
                player.SetWinning();                
            }                     
        }
    }
}
