using RollABall.Args;
using UnityEngine;

namespace RollABall.SO
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Roll a ball/Events/Game event", order = 2)]
    public class GameEvent : EventObserverBase<GameArgs>{}
}
