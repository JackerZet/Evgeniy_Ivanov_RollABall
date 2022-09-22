using UnityEngine;
using RollABall.SO;
using RollABall.UI;
using RollABall.Interactivity;

namespace RollABall.Player
{
    public class PlayerBall : MonoBehaviour
    {
        private const string Interactive = nameof(Interactive);
        [SerializeField] private PlayerStats stats;
        [SerializeField] private UIPlayerStats playerCanvas;

        [field: SerializeField] public int CureHP { get; set; }

        private void Start()
        {           
            CureHP = stats.MaxHP;
        }       
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Interactive)) return;
            if (other.gameObject.TryGetComponent(out IHealh healh))
            {
                CureHP = healh.IHealhChange(CureHP);
                if(playerCanvas != null) playerCanvas.HealthChange(this);
                if (CureHP <= 0) Destroy(gameObject);
                if (CureHP > stats.MaxHP) CureHP = stats.MaxHP;
            }
        }
    }
}
