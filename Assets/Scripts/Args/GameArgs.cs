using System;

namespace RollABall.Args
{
    public class GameArgs : EventArgs
    {
        public bool IsRestart { get; }
        public bool? IsWinGame { get; }
        public bool? IsDieGame { get; }        
        public GameArgs(bool isRestart, bool? isWin = null, bool? isDie = null)
        {
            IsWinGame = isWin;
            IsDieGame = isDie;
            IsRestart = isRestart;
        }
    }
}
