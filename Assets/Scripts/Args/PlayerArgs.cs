using System;

namespace RollABall.Args
{
    public class PlayerArgs : EventArgs
    {        
        public int CurentHP { get; }
        public int Keys { get; }
        public bool IsWin { get;}

        public PlayerArgs (int curentHP, int keys, bool isWin)
        {
            CurentHP = curentHP;
            Keys = keys;
            IsWin = isWin;
        }
    }
}

