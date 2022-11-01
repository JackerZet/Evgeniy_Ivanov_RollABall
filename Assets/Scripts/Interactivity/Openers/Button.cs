using UnityEngine;

namespace RollABall.Interactivity
{
    public class Button : Opener
    {
        private int _collisions;

        protected override void OnTriggerEnter(Collider other)
        {
            _collisions++;
            if (_collisions != 1) return;

            OpenAll();
        }
        protected void OnTriggerExit(Collider other)
        {
            _collisions--;
            if (_collisions != 0) return;
                       
            CloseAll();            
        }
        protected override void Interaction(GameObject gameobject) { }                
    }
}
