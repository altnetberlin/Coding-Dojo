using System;

namespace KataTennis
{
    class Player
    {
        public string Name;

        public Action NotifyWinsBall = delegate { };
        public int Score;

        public void WinsBall()
        {
            NotifyWinsBall();
        }
    }
}