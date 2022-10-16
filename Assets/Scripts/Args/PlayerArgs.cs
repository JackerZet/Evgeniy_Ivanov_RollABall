using System;

namespace RollABall.Args
{
    public class PlayerArgs : EventArgs
    {        
        public int CurentHP { get; }

        public PlayerArgs (int curentHP)
        {
            CurentHP = curentHP;
        }
    }
}

