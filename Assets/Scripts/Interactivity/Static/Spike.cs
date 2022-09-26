using RollABall.Interfaces;
using RollABall.Player;
using RollABall.SO;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class Spike : InteractiveObject, IHealthChangeable
    {
        [SerializeField] private float powerRepulsion = 5f;
        [SerializeField] private InterObjStats damage;
        
        [SerializeField] private DelegateEvent hitEvent;
        
        public int HealthChange(int health)
        {
            return health - damage.Damage;
        }
        protected override void Interaction(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out PlayerBall player))            
                player.SetHP(this);          
            if (gameObject.TryGetComponent(out Rigidbody rig))                
                rig.AddForce((rig.position - transform.position).normalized * powerRepulsion, ForceMode.Impulse);
            hitEvent.RaiseEvent();
        }
    }
}
