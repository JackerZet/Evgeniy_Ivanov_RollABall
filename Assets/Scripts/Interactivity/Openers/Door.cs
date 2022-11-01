using RollABall.Player;
using UnityEngine;

namespace RollABall.Interactivity
{
    public class Door : Locked
    {
        [Tooltip("Actuallity only for doors that open with a button")]
        [SerializeField] private bool closingOnPressButton;
        private void OnCollisionEnter(Collision collision)
        {
            base.OnTriggerEnter(collision.collider);
        }

        public override void Init(Opener opener)
        {
            opener.OpenEvent += OnOpening;
            opener.CloseEvent += OnClose;
        }
        public override void Dispose(Opener opener)
        {
            opener.OpenEvent -= OnOpening;
            opener.CloseEvent -= OnClose;
        }

        public override void OnClose(Opener opener)
        {
            gameObject.SetActive(!closingOnPressButton);
        }
        public override void OnOpening(Opener opener)
        {
            gameObject.SetActive(closingOnPressButton);
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
