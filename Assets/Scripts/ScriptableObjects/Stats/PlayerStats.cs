using RollABall.Objects;
using UnityEngine;

namespace RollABall.SO
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Roll a ball/Stats/Player stats", order = 0)]
    public class PlayerStats : ScriptableObject
    {
        [field: SerializeField] public int MaxHP { get; private set;}
        [field: SerializeField] public float TimeOfInvulnerability { get; private set; }
        [field: SerializeField] public Material StartMaterial { get; private set; }
        [field: SerializeField] public Material InvulnerabilityMaterial { get; private set; }
    }
}