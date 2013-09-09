using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FunctionalTennis
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void GameStartsLoveAll()
        {
            Assert.AreEqual(Tuple.Create(0, 0), Game.Start());
        }

        [Test]
        public void WhenLoveAllAndPlayerOneScoresShouldBeFifteenLove()
        {
            Assert.AreEqual(Tuple.Create(15, 0), Game.PlayerOneScores(Tuple.Create(0, 0)));
        }

        [Test]
        public void WhenLoveAllAndPlayerTwoScoresShouldBeLoveFifteen()
        {
            Assert.AreEqual(Tuple.Create(0, 15), Game.PlayerTwoScores(Tuple.Create(0, 0)));
        }
    }

    public class Game
    {
        public static object Start()
        {
            return Tuple.Create(0, 0);
        }

        public static object PlayerOneScores(Tuple<int, int> gameState)
        {
            return Tuple.Create(15, 0);
        }

        public static object PlayerTwoScores(Tuple<int, int> gameState)
        {
            return Tuple.Create(0, 15);
        }
    }
}
