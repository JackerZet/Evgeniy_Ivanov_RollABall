using RollABall.Player;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall.UI
{
    public class UIPlayerStats : MonoBehaviour
    {
        [SerializeField] private Image[] cureHearts;
        [SerializeField] private Sprite filledHeart;
        [SerializeField] private Sprite emptyHeart;
        
        public void HealthChange(PlayerBall player)
        {
            for(int index = 0; index < cureHearts.Length; index++)
            {
                cureHearts[index].sprite = index < player.CureHP ? filledHeart : emptyHeart;
            }            
        }
    }
}
