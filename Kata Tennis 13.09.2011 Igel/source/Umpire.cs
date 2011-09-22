using System;

namespace KataTennis
{
    class Umpire
    {
        readonly Player _player1;
        readonly Player _player2;

        readonly string[] _scores = new[] {"love", "fifteen", "thirty", "fourty", "Advantage", "wins set"};

        public Umpire(Player _player1, Player _player2)
        {
            this._player1 = _player1;
            this._player2 = _player2;

            _player1.NotifyWinsBall += () => ReScore(_player1);
            _player2.NotifyWinsBall += () => ReScore(_player2);
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
            if (player.Score == opponent.Score && player.Score == 3)
            {
                Console.WriteLine("Deuce");
            }
            else
            {
                Console.WriteLine("{0} {1}", player.Name, _scores[player.Score]);
                Console.WriteLine("{0} {1}", opponent.Name, _scores[opponent.Score]);
            }
        }
    }
}