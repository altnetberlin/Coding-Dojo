using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using GameState = System.Tuple<int, int>;

namespace FunctionalTennis
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void GameStartsLoveAllFunctional()
        {
            AssertCorrectState(Tuple.Create(0, 0), new Func<GameState, GameState>[0]);
        }

        [Test]
        public void WhenLoveAllAndPlayerOneScoresShouldBeFifteenLoveFunctional()
        {
            AssertCorrectState(Tuple.Create(15, 0), new Func<GameState, GameState>[] { Game.PlayerOneScores });
        }

        [Test]
        public void WhenLoveAllAndPlayerTwoScoresShouldBeFifteenLoveFunctional()
        {
            AssertCorrectState(Tuple.Create(0, 15), new Func<GameState, GameState>[] { Game.PlayerTwoScores });
        }

        [Test]
        public void WhenLoveAllAndPlayerOneScoresShouldBeThirtyLoveFunctional()
        {
            AssertCorrectState(Tuple.Create(30, 0), new Func<GameState, GameState>[]
                                                        {
                                                            Game.PlayerOneScores, 
                                                            Game.PlayerOneScores,
                                                        });
        }

        //[Test]
        //public void WhenLoveAllAndPlayerOneScoresShouldBeFortyLoveFunctional()
        //{
        //    AssertCorrectState(Tuple.Create(40, 0), new Func<GameState, GameState>[]
        //                                                {
        //                                                    Game.PlayerOneScores, 
        //                                                    Game.PlayerOneScores,
        //                                                    Game.PlayerOneScores,
        //                                                });
        //}

        private void AssertCorrectState(GameState expectedState, IEnumerable<Func<GameState, GameState>> actions)
        {
            var state = Game.State(actions);
            Assert.AreEqual(expectedState, state);
        }
    }

    public class Game
    {
        public static GameState PlayerOneScores(GameState gameState)
        {
            return Tuple.Create(gameState.Item1 + 15, 0);
        }

        public static GameState PlayerTwoScores(GameState gameState)
        {
            return Tuple.Create(0, 15);
        }

        public static GameState State(IEnumerable<Func<GameState, GameState>> actions)
        {
            return X(Tuple.Create(0, 0), actions);
        }

        static GameState X(GameState a, IEnumerable<Func<GameState, GameState>> list)
        {
            if (!list.Any())
                return a;

            var f = list.First();
            var rest = list.Skip(1);
            return X(f(a), rest);
        }
    }
}
