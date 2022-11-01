//using System.Collections.Generic;

namespace RollABall.Interactivity
{
    public abstract class Locked : InteractiveObject
    {
        //public List<Opener> Openers { get; } = new();     
        
        public abstract void Init(Opener opener);
        public abstract void Dispose(Opener opener);

        public abstract void OnClose(Opener opener);
        public abstract void OnOpening(Opener opener);      
    }
}
