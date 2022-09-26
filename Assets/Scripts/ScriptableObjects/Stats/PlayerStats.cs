using UnityEngine;

namespace RollABall.SO
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Roll a ball/Stats/Player stats", order = 0)]
    public class PlayerStats : ScriptableObject
    {
        [field: SerializeField] public int MaxHP { get; set;}
    }
}