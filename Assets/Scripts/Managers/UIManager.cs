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
        [SerializeField] private TMP_Text keys;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private Button but_restart;
        [SerializeField] private GameObject winAndDiePanel;

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
        #endregion

        #region Monobehavior methods
        private void OnEnable()
        {
            gameEvent.AddObserver(this);
            but_restart.onClick.AddListener(OnClickBut_Restart);
        }
        private void OnDisable() => Dispose();
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pause = _pause ? false : true;
                pauseMenu.SetActive(_pause);
                Time.timeScale = _pause ? 0 : 1;
            }
        }
        #endregion

        #region Functionality
        private void OnClickBut_Restart() => action.Invoke();
        private void HealthChange(PlayerArgs args)
        {                        
            for (int index = 0; index < cureHearts.Length; index++)
                cureHearts[index].sprite = index < args.CurentHP ? filledHeart : emptyHeart;                                                                   
        }
        private void KeysChange(PlayerArgs args)
        {
            keys.text = args.Keys.ToString();       
        }
        public void SetValues(PlayerArgs args)
        {
            if (cureHearts != null || filledHeart != null || emptyHeart != null) HealthChange(args);
            if (keys != null) KeysChange(args);
        }
        public void OnEventRaised(IHead<GameArgs> head, GameArgs args)
        {
            if(args.IsWinGame == true)
            {
                winAndDiePanel.SetActive(true);
                winAndDiePanel.GetComponentInChildren<TMP_Text>().text = "You win <3";
            }
            if (args.IsDieGame == true)
            {
                winAndDiePanel.SetActive(true);
                winAndDiePanel.GetComponentInChildren<TMP_Text>().text = "You die >_<";
            }
        }
        public void Dispose()
        {
            but_restart.onClick.RemoveAllListeners();
            gameEvent.RemovObserver(this);
        }
        #endregion
    }
}
