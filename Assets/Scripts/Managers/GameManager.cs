using RollABall.Args;
using RollABall.Interfaces;
using RollABall.Player;
using RollABall.SO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollABall.Managers
{
    public class GameManager : MonoBehaviour, IObserver<PlayerArgs>, IObserver<GameArgs>, System.IDisposable
    {
        #region Links
        [SerializeField] private PlayerBall player;

        [SerializeField] private UIManager ui;
        [Header("Events")]
        [SerializeField] private PlayerEvent playerEvent;
        [SerializeField] private GameEvent gameEvent;
        #endregion

        #region MonoBehaviour methods
        private void OnEnable() 
        {
            Time.timeScale = 1;
            playerEvent.AddObserver(this);
            gameEvent.AddObserver(this);
            ui.action += OnRestart;           
        }
        private void OnDisable() => Dispose();
        #endregion

        #region Functionality        

        public void OnRestart()
        {           
            SceneManager.LoadScene(0);
        }
        public void OnEventRaised(IHead<PlayerArgs> head, PlayerArgs args)
        {           
            ui.SetValues(args);

            if (args.CurentHP <= 0)                
                gameEvent.Notify(new GameArgs(false, null, true));
            if (player.IsWin) 
                gameEvent.Notify(new GameArgs(false, true, null));
        }

        public void OnEventRaised(IHead<GameArgs> head, GameArgs args)
        {        
            if (args.IsWinGame == true)
            {
                Debug.Log("You win)");
                Time.timeScale = 0;
            }
            if (args.IsDieGame == true)
            {
                Debug.Log("You die(");
                Time.timeScale = 0;
                Destroy(player.gameObject);
            }
        }

        public void Dispose()
        {
            playerEvent.RemovObserver(this);
            gameEvent.RemovObserver(this);
            ui.action -= OnRestart;
        }

        #endregion
    }
}
