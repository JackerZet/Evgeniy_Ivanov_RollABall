using RollABall.Args;
using RollABall.Interfaces;
using RollABall.SO;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall.Managers
{
    public class UIManager : MonoBehaviour, Interfaces.IObserver<GameArgs>, IDisposable
    {
        #region Links
        [Header("UI Components")]
        [SerializeField] private Image[] cureHearts;
        [SerializeField] private GameObject pauseMenu;
        [Space(10)]
        [SerializeField] private Button but_Restart;
        [SerializeField] private Button but_ExitToMenu;

        [Header("Result's components")]
        [SerializeField] private GameObject resultPanel;
        [SerializeField] private string winString = "You win <3";
        [SerializeField] private string dieString = "You die > _ <";

        [Header("Sprites of hearts")]
        [SerializeField] private Sprite filledHeart;
        [SerializeField] private Sprite emptyHeart;

        [Space(10)]
        [SerializeField] private GameEvent gameEvent;
        #endregion

        #region Event
        [HideInInspector] public Action action;
        #endregion

        #region Fields
        private bool _pause;
        private string _resultText;
        #endregion

        #region Monobehavior methods
        private void OnEnable()
        {
            gameEvent.AddObserver(this);
            but_Restart.onClick.AddListener(OnClickBut_Restart);
            but_ExitToMenu.onClick.AddListener(OnClickBut_ExitToMenu);
        }
        private void OnDisable() => Dispose();
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pause = !_pause;
                pauseMenu.SetActive(_pause);
                Time.timeScale = _pause ? 0 : 1;
            }
        }
        #endregion

        #region Functionality
        private void OnClickBut_Restart() => gameEvent.Notify(new GameArgs(true, false));
        private void OnClickBut_ExitToMenu() => gameEvent.Notify(new GameArgs(false, true));
        private void HealthChange(PlayerArgs args)
        {                        
            for (int index = 0; index < cureHearts.Length; index++)
                cureHearts[index].sprite = index < args.CurentHP ? filledHeart : emptyHeart;                                                                   
        }
        public void SetValues(PlayerArgs args)
        {
            if (cureHearts != null || filledHeart != null || emptyHeart != null) HealthChange(args);
        }
        public void OnEventRaised(IHead<GameArgs> head, GameArgs args)
        {
            if (args.ResultGame != GameResult.None)            
                ChangeWinAndDiePanel(args);           
        }
        public void Dispose()
        {
            but_Restart.onClick.RemoveAllListeners();
            but_ExitToMenu.onClick.RemoveAllListeners();
            gameEvent.RemovObserver(this);
        }
        private void ChangeWinAndDiePanel(GameArgs args)
        {            
            resultPanel.SetActive(true);
            _resultText = args.ResultGame switch
            {
                GameResult.IsWin => winString,
                GameResult.IsDie => dieString,
                _ => null
            };
            resultPanel.GetComponentInChildren<TMP_Text>().text = _resultText;                         
        }        
        #endregion
    }
}
