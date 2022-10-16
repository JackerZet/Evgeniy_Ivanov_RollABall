using System;

namespace RollABall.Args
{
    public enum GameResult
    {
        None,
        IsWin,
        IsDie
    }
    public class GameArgs : EventArgs
    {
        
        public bool IsRestart { get; }
        public bool IsExitToMenu { get; }
        public GameResult? ResultGame { get; }       
        public GameArgs(bool isRestart, bool isExitToMenu, GameResult? result = null)
        {
            ResultGame = result;
            IsRestart = isRestart;
            IsExitToMenu = isExitToMenu;
        }
    }    
}
