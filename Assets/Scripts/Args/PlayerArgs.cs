using System;

namespace RollABall.Args
{
    public class PlayerArgs : EventArgs
    {        
        public int CurentHP { get; }
        public int Keys { get; }

        public PlayerArgs (int curentHP, int keys)
        {
            CurentHP = curentHP;
            Keys = keys;
        }
    }
}

