using RollABall.Args;
using UnityEngine;

namespace RollABall.SO
{
    [CreateAssetMenu(fileName = "PlayerEvent", menuName = "Roll a ball/Events/Player event", order = 1)]
    public class PlayerEvent : EventObserverBase<PlayerArgs>{}
}
