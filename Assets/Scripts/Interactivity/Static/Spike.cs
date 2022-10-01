using RollABall.Interfaces;
using RollABall.Player;
using RollABall.SO;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class Spike : InteractiveObject, IHealthChangeable, IHitting
    {
        [SerializeField] private float powerRepulsion = 5f;
        [SerializeField] private InterObjStats damage;
        
        public int HealthChange(int health)
        {
            return health - damage.Damage;    
        }

        protected override void Interaction(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out PlayerBall player))
            {
                player.SetHP(this);
                player.SetInvulnerability();                
            }                          
            if (gameObject.TryGetComponent(out Rigidbody rig))                
                rig.AddForce((rig.position - transform.position).normalized * powerRepulsion, ForceMode.Impulse);           
        }
    }
}
