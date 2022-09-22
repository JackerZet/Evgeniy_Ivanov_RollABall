using UnityEngine;

namespace RollABall.Interactivity
{
    public class Spike : InteractiveObject, IHealh
    {
        [SerializeField] private float repulsion = 5f;
        [SerializeField] private int damage = 1;

        public int IHealhChange(int health)
        {
            return health - damage;
        }
        protected override void Interaction(GameObject gameObject)
        {            
            var rig = gameObject.GetComponent<Rigidbody>();
            if (!rig) return;           
            rig.AddForce((rig.position - transform.position).normalized * repulsion, ForceMode.Impulse);                    
        }
    }
}
