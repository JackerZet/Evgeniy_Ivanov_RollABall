using UnityEngine;

namespace RollABall.SO
{
    [CreateAssetMenu(fileName = "Interactivity's stats", menuName = "Roll a ball/Stats/Interactivity's stats", order = 5)]
    public class InterObjStats : ScriptableObject
    {
        [field: SerializeField] public int Damage { get; set; }
        [field: SerializeField] public int Heal { get; set; }
    }
}
