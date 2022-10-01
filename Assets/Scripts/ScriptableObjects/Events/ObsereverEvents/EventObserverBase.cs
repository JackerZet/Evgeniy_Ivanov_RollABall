using RollABall.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall.SO
{
    public class EventObserverBase<T> : ScriptableObject, IHead<T>
    {
        private readonly List<IObserver<T>> _observers = new();

        public void AddObserver(IObserver<T> observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);
        }

        public void RemovObserver(IObserver<T> observer)
        {
            if (_observers.Contains(observer)) _observers.Remove(observer);
        }

        public void Notify(T args)
        {
            foreach (var observer in _observers)
            {
                observer.OnEventRaised(this, args);
            }
        }
    }
}
