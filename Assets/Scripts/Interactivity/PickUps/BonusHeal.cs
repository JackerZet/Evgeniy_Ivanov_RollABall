using RollABall.Interfaces;
using RollABall.Player;
using RollABall.SO;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class BonusHeal : InteractiveObject, IHealthChangeable
    {
        [SerializeField] private InterObjStats heal;
        
        public int HealthChange(int health)
        {
            return health + heal.Heal;
        }       
        protected override void Interaction(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out PlayerBall player))
            {
                player.SetHP(this);
                this.gameObject.SetActive(false);
            }            
        }
    }
}