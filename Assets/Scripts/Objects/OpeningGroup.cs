using RollABall.Interactivity;
using System;
using UnityEngine;

namespace RollABall.Objects
{
    [Serializable]
    public class OpeningGroup : IDisposable
    {
        [field: SerializeField] public Opener Opener { get; private set; }
        [field: SerializeField] public Locked Locked { get; private set; }
        public void SetGroup()
        {
            Opener.Lockeds.Add(Locked);
            //Locked.Openers.Add(Opener);
        }  
        
        public void Init()
        {
            Locked.Init(Opener);
        }
        public void Dispose()
        {
            Locked.Dispose(Opener);
        }
    }
}
