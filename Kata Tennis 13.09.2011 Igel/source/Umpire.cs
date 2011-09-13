using System;
using System.Diagnostics;

namespace KataTennis
{
    class Umpire
    {
        private Player _player1;
        private Player _player2;

        private string[] _scores = new[]{"0", "15", "30", "40", "Advantage", "wins set"};
     
        public Umpire(Player _player1, Player _player2)
        {
            this._player1 = _player1;
            this._player2 = _player2;

            _player1.NotifyWinsBall += ()=> ReScore(_player1);
        }

        void ReScore(Player player)
        {
            Player opponent = player == _player1 ? _player2 : _player1;
            // direct-win
            if (player.Score == 3 && opponent.Score < 3)
                player.Score = 5;            
            // advantage
            else if (player.Score == 3 && opponent.Score == 4)
            {                
                opponent.Score = 3;
            }
            else
            {
                player.Score++;
            }
            Console.WriteLine("{0} {1}", player.Name, _scores[player.Score]);
            Console.WriteLine("{0} {1}", opponent.Name, _scores[opponent.Score]);
        }
    }
}