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

        [Header("Events")]
        [SerializeField] private PlayerEvent playerEvent;
        [SerializeField] private GameEvent gameEvent;
        [SerializeField] private DelegateEvent delegateEvent;
        #endregion

        #region Properties        
        [field: Header("Properties")]
        [field: SerializeField] public int CureHP { get; private set; }
        #endregion

        #region Fields
        private bool _isChanged;
        private bool _invulnerability;

        private MeshRenderer _cureMesh;        
        #endregion

        #region MonoBehaviour methods
        private void Start()
        {
            CureHP = stats.MaxHP;
            _cureMesh = GetComponentInChildren<MeshRenderer>();
            StartCoroutine(Coroutine_ChangeArgs());
        }
        private void OnDestroy()
        {
            StopCoroutine(Coroutine_ChangeArgs());
        }
        #endregion

        #region Functionality
        public void SetHP(IHealthChangeable i)
        {
            if (i is IHitting && !_invulnerability)
            {
                StartCoroutine(Coroutine_ChangeBallAfterHit());
                CureHP = i.HealthChange(CureHP);

                if (delegateEvent != null)
                {
                    delegateEvent.RaiseEvent();
                }                   
            }
            else if (i is not IHitting)
            {
                CureHP = i.HealthChange(CureHP);
            }

            _isChanged = true;
        }
        public void SetWinning()
        {
            gameEvent.Notify(new GameArgs(false, false, GameResult.IsWin));
        }
        private IEnumerator Coroutine_ChangeBallAfterHit()
        {
            _invulnerability = true;
            for (int i = 0; i < stats.TimeOfInvulnerability * 2; i++)
            {
                _cureMesh.material = stats.InvulnerabilityMaterial;
                yield return new WaitForSeconds(stats.TimeOfInvulnerability / 8);
                _cureMesh.material = stats.StartMaterial;
                yield return new WaitForSeconds(stats.TimeOfInvulnerability / 8);
            }
            _invulnerability = false;
        }
        private IEnumerator Coroutine_ChangeArgs()
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
            if (CureHP > stats.MaxHP)
            {
                CureHP = stats.MaxHP;
            }

            if (CureHP <= 0)
            {
                gameEvent.Notify(new GameArgs(false, false, GameResult.IsDie));
            } 
            
            playerEvent.Notify(new PlayerArgs(CureHP));
        }
        #endregion
    }
}
