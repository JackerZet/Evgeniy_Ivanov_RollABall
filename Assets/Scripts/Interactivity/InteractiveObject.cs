using UnityEngine;

namespace RollABall.Interactivity
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        protected virtual void OnTriggerEnter(Collider other)
        {           
            Interaction(other.gameObject);
        }        
        protected abstract void Interaction(GameObject gameobject);
    }
}