using RollABall.Player;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class Key : Opener
    {
        //private Vector3 _closestPoint;           
        public void Open(Locked locker)
        {
            locker.OnOpening(this);
            gameObject.SetActive(false);           
        }

        protected override void Interaction(GameObject gameObject)
        {            
            if (gameObject.TryGetComponent(out BunchOfKeys player))
            {
                player.SetKeys(this);
            }
        }

        

        /*protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            _closestPoint = other.ClosestPoint(transform.position);
                       
        }
        public void Collise(ref Vector3 c)
        {
            c = Vector3.Lerp(c, (transform.position - _closestPoint).normalized, 0.1f);
            transform.Translate(c);
        }*/
    }   
}
