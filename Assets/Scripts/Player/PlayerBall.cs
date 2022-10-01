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
        [field: SerializeField] public int CureHP { get; set; }
        [field: SerializeField] public int Keys { get; set; }
        [field: SerializeField] public bool IsWin { get;set; }
        [field: SerializeField] public bool Invulnerability { get; set; }
        #endregion

        #region Fields
        private bool _isChanged;
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
            if(i is IHitting && !Invulnerability)
            {
                CureHP = i.HealthChange(CureHP);
                delegateEvent.RaiseEvent();                                                 
            }
            else if(i is not IHitting)
                CureHP = i.HealthChange(CureHP);
            
            _isChanged = true;
        }
        public void SetInvulnerability()
        {
            if (!Invulnerability)               
                StartCoroutine(ChangePlayerAfterHit());           
        }
        private IEnumerator ChangePlayerAfterHit()
        {
            Invulnerability = true;
            for (int i = 0; i < stats.TimeOfInvulnerability * 2 ; i++)
            {
                _cureMesh.material = stats.InvulnerabilityMaterial;
                yield return new WaitForSeconds(stats.TimeOfInvulnerability / 8);
                _cureMesh.material = stats.StartMaterial;
                yield return new WaitForSeconds(stats.TimeOfInvulnerability / 8);
            }
            Invulnerability = false;
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
            if (CureHP > stats.MaxHP) CureHP = stats.MaxHP;

            var playerArgs = new PlayerArgs(
                CureHP,
                Keys
                );                      
            playerEvent.Notify(playerArgs);           
        }
        #endregion
    }
}
