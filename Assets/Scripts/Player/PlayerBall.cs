using UnityEngine;
using RollABall.SO;
using RollABall.Interfaces;
using System.Collections;
using RollABall.Args;

namespace RollABall.Player
{
    public class PlayerBall : MonoBehaviour
    {
        #region Links
        [Tooltip("Stats on start game")]
        [SerializeField] private PlayerStats stats;
        [SerializeField] private PlayerEvent playerEvent;
        #endregion

        #region Consts
        private const string Interactive = nameof(Interactive);
        #endregion

        #region Properties
        [field: SerializeField] public int CureHP { get; set; }
        [field: SerializeField] public int Keys { get; set; }
        [field: SerializeField] public bool IsWin { get; set; }       
        #endregion

        #region Fields
        private bool _isChanged = false;
        #endregion

        #region MonoBehaviour methods
        private void Start()
        {           
            CureHP = stats.MaxHP;
            StartCoroutine(EventToChangeArgs());
        }
        private void OnDestroy()
        {
            StopCoroutine(EventToChangeArgs());
        }
        #endregion

        #region Functionality
        public void SetHP(IHealthChangeable i)
        {           
            CureHP = i.HealthChange(CureHP);
            _isChanged = true;
        }

        public void SetKeys(IKeyAndDoorable i)
        {
            Keys = i.KeysChange(Keys);
            _isChanged = true;
        }

        public void SetWinning()
        {
            IsWin = true;
            _isChanged = true;
        }

        private IEnumerator EventToChangeArgs()
        {
            while (true)
            {
                yield return new WaitUntil(() => _isChanged);
                ChangeArgs();
                _isChanged = false;
            }
        }
        private void ChangeArgs()
        {
            if (CureHP > stats.MaxHP) CureHP = stats.MaxHP;

            var args = new PlayerArgs(
                CureHP,
                Keys,
                IsWin
                );
            playerEvent.Notify(args);
        }
        #endregion
    }
}
