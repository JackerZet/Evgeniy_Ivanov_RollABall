using RollABall.Args;
using RollABall.Interfaces;
using RollABall.SO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall.Managers
{
    public class UIManager : MonoBehaviour, IObserver<PlayerArgs>
    {
        #region Links
        [Header("UI Components")]
        [SerializeField] private Image[] cureHearts;
        [SerializeField] private TMP_Text keys;

        [Header("Sprites of hearts")]
        [SerializeField] private Sprite filledHeart;
        [SerializeField] private Sprite emptyHeart;

        [Header("Events")]
        [SerializeField] private PlayerEvent playerEvent;
        #endregion

        #region MonoBehaviour methods
        private void OnEnable() => playerEvent.AddListener(this);                          
        private void OnDisable() => playerEvent.RemoveListener(this);
        #endregion

        #region Functionality
        private void HealthChange(PlayerArgs args)
        {
            for (int index = 0; index < cureHearts.Length; index++)            
                cureHearts[index].sprite = index < args.CurentHP ? filledHeart : emptyHeart;                       
        }

        private void KeysChange(PlayerArgs args)
        {
            keys.text = args.Keys.ToString();
        }

        public void OnEventRaised(IHead<PlayerArgs> head, PlayerArgs args)
        {
            if (cureHearts != null) HealthChange(args);
            if (keys != null) KeysChange(args);
        }
        #endregion
    }
}
