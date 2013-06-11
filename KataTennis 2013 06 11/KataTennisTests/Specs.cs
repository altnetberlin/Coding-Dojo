using System;
using System.Linq;
using KataTennis;
using Machine.Specifications;

namespace KataTennisTests
{
    [Subject("Score")]
    public class WhenNewGameStarts
    {
        Because of = () => { game = new Game(); };

        It should_be_love_for_playerA = () => game.PlayerA.ShouldEqual(PlayerState.Love);

        It should_be_love_for_playerB = () => game.PlayerB.ShouldEqual(PlayerState.Love);

        static Game game;
    }

    public class WithNewGame
    {
        Establish ctx = () => { Game = new Game(); };

        protected static Game Game;
    }

    [Subject("Score")]
    public class When_First_ScoreOfGameGoesToPlayerA : WithNewGame
    {
        Because of = () => Game.ScoreForPlayerA();

        It should_be_fifteen_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Fifteen);

        It should_be_love_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Love);
    }

    [Subject("Score")]
    public class WhenFirstTwoScoresOfGameGoToPlayerA : WithNewGame
    {
        Establish ctx = () => Game.ScoreForPlayerA();

        Because of = () => Game.ScoreForPlayerA();

        It should_be_thirty_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Thirty);

        It should_be_love_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Love);
    }

    [Subject("Score")]
    public class WhenFirstThreeScoresOfGameGoToPlayerA : WithNewGame
    {
        private Establish ctx = () =>
                                    {
                                        Game.ScoreForPlayerA();
                                        Game.ScoreForPlayerA();
                                    };

        Because of = () => Game.ScoreForPlayerA();

        It should_be_forty_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Forty);

        It should_be_love_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Love);
    }

    [Subject("Score")]
    public class WhenFirstFourScoresOfGameGoToPlayerA : WithNewGame
    {
        private Establish ctx = () =>
        {
            Game.ScoreForPlayerA();
            Game.ScoreForPlayerA();
            Game.ScoreForPlayerA();
        };

        Because of = () => Game.ScoreForPlayerA();

        It should_indicate_win_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Winner);

        It should_be_love_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Love);
    }

    [Subject("Score")]
    public class WhenPlayerAWonAndScoresAgain : WithNewGame
    {
        private Establish ctx = () =>
        {
            Game.ScoreForPlayerA();
            Game.ScoreForPlayerA();
            Game.ScoreForPlayerA();
            Game.ScoreForPlayerA();
        };

        Because of = () => exception = Catch.Exception(Game.ScoreForPlayerA);

        It should_throw_an_exception = () => exception.ShouldNotBeNull();

        It should_throw_an_invalid_operation_exception = () => exception.ShouldBeOfType<InvalidOperationException>();

        It should_indicate_win_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Winner);

        It should_be_love_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Love);

        private static Exception exception;
    }

    [Subject("Score")]
    public class WhenFirstFourScoresOfGameGoToPlayerB : WithNewGame
    {
        private Establish ctx = () =>
        {
            Game.ScoreForPlayerB();
            Game.ScoreForPlayerB();
            Game.ScoreForPlayerB();
        };

        Because of = () => Game.ScoreForPlayerB();

        It should_be_love_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Love);

        It should_indicate_win_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Winner);
    }

    public class WithFortyAll : WithNewGame
    {
        private Establish ctx = () =>
        {
            Game.ScoreForPlayerA();
            Game.ScoreForPlayerA();
            Game.ScoreForPlayerA();
            Game.ScoreForPlayerB();
            Game.ScoreForPlayerB();
            Game.ScoreForPlayerB();
        };
    }

    [Subject("Score")]
    public class WhenFortyAllAndNextBallGoesToPlayerA : WithFortyAll
    {
        Because of = () => Game.ScoreForPlayerA();

        It should_indicate_advantage_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Advantage);

        It should_be_forty_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Forty);
    }


    [Subject("Score")]
    public class WhenFortyAllAndNextBallGoesToPlayerB : WithFortyAll
    {
        Because of = () => Game.ScoreForPlayerB();

        It should_be_forty_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Forty);

        It should_indicate_advantage_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Advantage);
    }

    [Subject("Score")]
    public class WhenAdvantagePlayerAAndNextBallGoesToPlayerB : WithFortyAll
    {
        Establish ctx = () => Game.ScoreForPlayerA();

        Because of = () => Game.ScoreForPlayerB();

        It should_be_forty_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Forty);

        It should_be_forty_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Forty);
    }

    [Subject("Score")]
    public class WhenAdvantagePlayerAAndNextBallGoesToPlayerA : WithFortyAll
    {
        Establish ctx = () => Game.ScoreForPlayerA();

        Because of = () => Game.ScoreForPlayerA();

        It should_indicate_win_for_playerA = () => Game.PlayerA.ShouldEqual(PlayerState.Winner);

        It should_be_forty_for_playerB = () => Game.PlayerB.ShouldEqual(PlayerState.Forty);
    }
}