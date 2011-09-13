using System.Collections.Generic;
using Machine.Specifications;

namespace KataTennis
{

    public class Game
    {
        List<int> _scoreValues = new List<int>{ {0}, {15}, {30}, {40}, {50} };

        public Game()
        {
            CurrentScore = new GameScore(0,0);
        }
        public void Start(GameScore gameScore)
        {
            CurrentScore = gameScore;
        }

        public GameScore CurrentScore { get; private set; }

        public void Player1Scores()
        {
            int value = _scoreValues[_scoreValues.IndexOf(CurrentScore.PlayerScore1) + 1];
            CurrentScore = new GameScore(value, 0);
        }
    }


    public static class GameScoreExtensions
    {
        public static string HumanReadable(this GameScore This)
        {
            if (This.PlayerScore1 == 50)
            return "Player 1 won";
            return string.Format("{0} - {1}", This.PlayerScore1, This.PlayerScore2);
        }
    }

    [Subject(typeof(Game))]
    public class when_create_a_new_tennis_game : Given_In_Game
    {
        Because of = () => _game.Start(new GameScore(0, 0));


        It should_player1_have_40_points_ = () => { _game.CurrentScore.HumanReadable().ShouldEqual("0 - 0"); };
    }

    [Subject(typeof (Game))]
    public class When_GameScore_is_Zero_to_Zero_and_Player1_scores : Given_In_Game
    {
        Because of = () => { _game.Player1Scores(); };


        It should_player1_have_40_points_ = () => { _game.CurrentScore.HumanReadable().ShouldEqual("15 - 0"); };
    }


    [Subject(typeof(Game))]
    public class Given_In_Game
    {
        Establish context = () => { _game = new Game(); };
        protected static Game _game;
    }


    [Subject(typeof(Game))]
    public class When_GameScore_is_15_0_and_Player1_scores : Given_In_Game
    {
        Establish context = () => { _game.Start(new GameScore(15,0)); };

        Because of = () => { _game.Player1Scores(); };


        It should_player1_have_40_points_ = () => { _game.CurrentScore.HumanReadable().ShouldEqual("30 - 0"); };
    }

    [Subject(typeof(Game))]
    public class When_GameScore_is_30_0_and_Player1_scores : Given_In_Game
    {
        Establish context = () => { _game.Start(new GameScore(30, 0)); };

        Because of = () => { _game.Player1Scores(); };

        It should_player1_have_40_points_ = () => { _game.CurrentScore.HumanReadable().ShouldEqual("40 - 0");};
    }

    [Subject(typeof(Game))]
    public class When_GameScore_is_40_0_and_Player1_scores : Given_In_Game
    {
        Establish context = () => { _game.Start(new GameScore(40, 0)); };

        Because of = () => { _game.Player1Scores(); };

        It should_player1_have_won_ = () => { _game.CurrentScore.HumanReadable().ShouldEqual("Player 1 won"); };
    }

    public class GameScore
    {
        public readonly int PlayerScore1;
        public readonly int PlayerScore2;

        public GameScore(int playerScore1, int playerScore2)
        {
            PlayerScore1 = playerScore1;
            PlayerScore2 = playerScore2;
        }
    }
}