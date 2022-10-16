using RollABall.Interfaces;
using RollABall.Player;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class Door : InteractiveObject, ILockable
    {
        public List<int> Index { get; set; } = new();

        public void Unlock()
        {
            gameObject.SetActive(false);
        }
        private void OnCollisionEnter(Collision collision)
        {
            base.OnTriggerEnter(collision.collider);
        }
        protected override void Interaction(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out BunchOfKeys player))
            {
                player.SetKeys(this);               
            }
        }        
    }
}
