using System;
using UnityEngine;

namespace RollABall.SO
{
    [CreateAssetMenu(fileName = "DelegateEvent", menuName = "Roll a ball/Events(Delegate)/Delegate event", order = 3)]
    public class DelegateEvent : ScriptableObject
    {
        private Action _onEventRaised;

        public virtual void RegisterListener(Action action)
        {
            _onEventRaised += action;
        }

        public virtual void UnregisterListener(Action action)
        {
            _onEventRaised -= action;
        }

        public virtual void RaiseEvent()
        {
            _onEventRaised?.Invoke();
        }
    }
}
