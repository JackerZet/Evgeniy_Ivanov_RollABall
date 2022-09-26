using RollABall.Args;
using RollABall.Interfaces;
using RollABall.Player;
using RollABall.SO;
using UnityEngine;

namespace RollABall.Managers
{
    public class GameManager : MonoBehaviour, IObserver<PlayerArgs>
    {
        #region Links
        [SerializeField] private PlayerBall player;        

        [Header("Events")]
        [SerializeField] private PlayerEvent playerEvent;
        #endregion

        #region MonoBehaviour methods
        private void OnEnable() => playerEvent.AddListener(this);
        private void OnDisable() => playerEvent.RemoveListener(this);
        #endregion

        #region Functionality
        public void OnEventRaised(IHead<PlayerArgs> head, PlayerArgs args)
        {
            var win = args.IsWin;
            var die = args.CurentHP <= 0;

            if (win)
            {
                Debug.Log("You win)");
            }
            if (die) 
            { 
                Debug.Log("You die(");
                Destroy(player.gameObject);
            }           
        }
        #endregion
    }
}
