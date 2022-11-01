using System.Collections.Generic;
//using System.Linq;

namespace RollABall.Interactivity
{
    public abstract class Opener : InteractiveObject
    {
        public List<Locked> Lockeds { get; } = new();

        public delegate void OpenerDelegate(Opener opener);

        public event OpenerDelegate OpenEvent;
        public event OpenerDelegate CloseEvent;
        public virtual void OpenAll()
        {
            //if (Lockeds.Find(l => l == locked))           
            OpenEvent.Invoke(this);//locked.OnOpening(this);           
        }
        public virtual void CloseAll()
        {
            //if (Lockeds.Find(l => l == locked))            
            CloseEvent.Invoke(this);//locked.OnClose(this);            
        }
    }
}
