using RollABall.Interactivity;
using System;

namespace RollABall.Args
{
    public class KeyArgs : EventArgs
    {
        public enum KeysAction 
        { 
            Add, 
            Remove 
        }
        public Key CollectedKey { get; } 
        public KeysAction KeysChanging { get; }
        public KeyArgs(KeysAction keysAction, Key key)
        {
            KeysChanging = keysAction;
            CollectedKey = key;           
        }
    }
}
