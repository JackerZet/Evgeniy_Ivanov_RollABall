using UnityEngine;

namespace RollABall.SO
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "RollABall/Stats/PlayerStats", order = 0)]
    public class PlayerStats : ScriptableObject
    {
        [field: SerializeField] public int MaxHP { get; set;}
    }
}