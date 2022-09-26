using RollABall.Interfaces;
using RollABall.Player;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class Door : InteractiveObject, IKeyAndDoorable
    {
        [HideInInspector] public bool _isOpen;

        protected void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            Interaction(collision.gameObject);
        }
        public int KeysChange(int keys)
        {
            return keys - 1;
        }

        protected override void Interaction(GameObject gameObject)
        {
            if (_isOpen && gameObject.TryGetComponent(out PlayerBall player))
            {
                player.SetKeys(this);
                this.gameObject.SetActive(false);
            }
        }
    }
}
