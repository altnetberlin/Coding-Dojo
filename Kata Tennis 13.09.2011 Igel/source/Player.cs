using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataTennis
{
    class Player
    {
        public int Score;
        public string Name;

        public Action NotifyWinsBall = delegate { };

        public void WinsBall()
        {
            this.NotifyWinsBall();
        }
    }
}
