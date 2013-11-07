using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClient
{
    public class Class1
    {
        public static void Main()
        {
            Console.WriteLine(FSharpTennis.playerScores(
                FSharpTennis.Player.PlayerOne, 
                FSharpTennis.GameScore.NewPoints(
                    FSharpTennis.Score.Love, 
                    FSharpTennis.Score.Love)));
        }
    }
}
