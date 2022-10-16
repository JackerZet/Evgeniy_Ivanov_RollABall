using RollABall.Args;
using UnityEngine;

namespace RollABall.SO
{
    [CreateAssetMenu(fileName = "KeyEvent", menuName = "Roll a ball/Events/Key event", order = 6)]
    public class KeyEvent : EventObserverBase<KeyArgs> { }
}
