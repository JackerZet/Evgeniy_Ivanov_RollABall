using RollABall.Player;
using RollABall.Interfaces;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class Key : InteractiveObject, IKeyAndDoorable
    {
        public int KeysChange(int keys)
        {
            return keys + 1;
        }

        protected override void Interaction(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out PlayerBall player))
            {
                player.SetKeys(this);
                this.gameObject.SetActive(false);
            }
        }
    }
}
