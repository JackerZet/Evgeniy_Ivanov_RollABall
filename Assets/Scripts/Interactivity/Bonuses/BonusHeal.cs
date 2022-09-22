using UnityEngine;

namespace RollABall.Interactivity
{
    public class BonusHeal : InteractiveObject, IHealh
    {
        [SerializeField] private int heal = 1;
        
        public int IHealhChange(int health)
        {
            return health + heal;
        }

        protected override void Interaction(GameObject gameobject)
        {
            Destroy(gameObject);
        }
    }
}