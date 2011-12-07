using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tennis
{
    public class Referee
    {
        private Player player1;
        private Player player2;

        public Referee(Player player1, Player player2)
        {
            // TODO: Complete member initialization
            this.player1 = player1;
            this.player2 = player2;
        }


        public void AddPointToPlayer(Player player)
        {
            Player otherPlayer;

            if(player == player1 )
            {
                otherPlayer = player2;
            }
            else
            {
                otherPlayer = player1;
            }

            if(otherPlayer.Points == Points.Fourty && player.Points == Points.Fourty)
            {
                player1.Points = player2.Points = Points.Deuce;
                return;
            }

            if(otherPlayer.Points == Points.Advantage)
            {
                player.Points = otherPlayer.Points = Points.Deuce;
            }
            ////////////////////////////////////////


            if (player.Points == Points.Fourty)
                player.Points = Points.Win;
            else
                player.Points++;
        }

        public Points GetPointsOfPlayer(Player player)
        {
            return (Points)player.Points;
        }
    }
}
