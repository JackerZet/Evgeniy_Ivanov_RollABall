using RollABall.Args;
using RollABall.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall.SO
{
    [CreateAssetMenu(fileName = "PlayerEvent", menuName = "Roll a ball/Events/Player event", order = 1)]
    public class PlayerEvent : ScriptableObject, IHead<PlayerArgs>
    {
        private readonly List<IObserver<PlayerArgs>> _observers = new();

        public void AddListener(IObserver<PlayerArgs> observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);
        }

        public void RemoveListener(IObserver<PlayerArgs> observer)
        {
            if (_observers.Contains(observer)) _observers.Remove(observer);
        }

        public void Notify(PlayerArgs args)
        {
            foreach (var observer in _observers)
            {
                observer.OnEventRaised(this, args);
            }
        }
    }
}
