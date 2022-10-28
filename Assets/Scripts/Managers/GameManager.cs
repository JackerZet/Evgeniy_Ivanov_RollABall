using RollABall.Args;
using RollABall.Interfaces;
using RollABall.Player;
using RollABall.SO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollABall.Managers
{
    public class GameManager : MonoBehaviour, IObserver<PlayerArgs>, IObserver<GameArgs> ,System.IDisposable
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
        }
        private void OnDisable() => Dispose();
        #endregion

        #region Functionality               
        public void OnEventRaised(IHead<PlayerArgs> head, PlayerArgs args)
        {           
            ui.SetValues(args);                                                 
        }
        public void OnEventRaised(IHead<GameArgs> head, GameArgs args)
        {        
            if (args.IsRestart == true)            
                OnRestart();

            if (args.IsExitToMenu == true)
                OnExitToMenu();

            if (args.ResultGame != GameResult.None)            
                Time.timeScale = 0;
            
            if (args.ResultGame == GameResult.IsDie)                    
                Destroy(player.gameObject);            
        }
        private void OnRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        private void OnExitToMenu()
        {
            SceneManager.LoadScene(0);
        }
        public void Dispose()
        {
            playerEvent.RemovObserver(this);
            gameEvent.RemovObserver(this);
            ui.action -= OnRestart;
            ui.action -= OnExitToMenu;
        }
        #endregion
    }
}
