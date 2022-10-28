using RollABall.Player;
using System.Collections;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class Key : Opener
    {

        private Vector3 _closestPoint;
            
        public override void Open()
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        public Vector3 FollowWitnDistance(Vector3 follower, Vector3 target, float height, float distance, float speed)
        {
            Vector3 curePos = target - (target - follower).normalized * distance;
            curePos.y += height;

            return Vector3.Lerp(follower, curePos, speed * Time.deltaTime);
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
