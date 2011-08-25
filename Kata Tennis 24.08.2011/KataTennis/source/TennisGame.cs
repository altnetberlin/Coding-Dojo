using System.Collections.Generic;
using Machine.Specifications;

namespace KataTennis
{
    public class TennisGame
    {
        Dictionary<int, int> _scoreMap = new Dictionary<int, int>() {{0, 0}, {1, 15}, {2, 30}, {3, 40}}; 

        public readonly PlayerScore Player1;
        public readonly PlayerScore Player2;

        public TennisGame()
            : this(new PlayerScore(0), new PlayerScore(0))
        {
        }

        public TennisGame(PlayerScore player1, PlayerScore player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public bool Player1Wins
        {
            get { return true; }
        }

        public void Player1Scores()
        {
            Player1.Scores();
        }

        public void Player2Scores()
        {
            Player2.Scores();
        }
    }

    class when_a_game_begins
    {
        Because of = () => game = new TennisGame();

        It should_announce_love_for_player_1 = () => game.Player1.Score.ShouldEqual(0);

        It should_announce_love_for_player_2 = () => game.Player2.Score.ShouldEqual(0);

        static TennisGame game;
    }

    class when_a_game_begins_and_player1_scores
    {
        static TennisGame game;
        Establish context = () => game = new TennisGame();

        Because of = () => game.Player1Scores();

        It should_announce_15_for_player_1 = () => game.Player1.Score.ShouldEqual(15);
        It should_announce_love_for_player_2 = () => game.Player2.Score.ShouldEqual(0);
    }

    class when_a_game_begins_and_player2_scores
    {
        static TennisGame game;
        Establish context = () => game = new TennisGame();

        Because of = () => game.Player2Scores();

        It should_announce_love_for_player_1 = () => game.Player1.Score.ShouldEqual(0);
        It should_announce_15_for_player_2 = () => game.Player2.Score.ShouldEqual(15);
    }

    class when_player1_has_15_and_scores
    {
        Establish context = () =>
            {
                game = new TennisGame(new PlayerScore(1), new PlayerScore(0));
            };

        Because of = () => game.Player1Scores();

        It should_announce_30_for_player_1 = () => game.Player1.Score.ShouldEqual(30);
        static TennisGame game;
    }

    class when_player2_has_15_and_scores
    {
        Establish context = () =>
        {
            game = new TennisGame(new PlayerScore(0), new PlayerScore(1));
        };

        Because of = () => game.Player2Scores();

        It should_announce_30_for_player_2 = () => game.Player2.Score.ShouldEqual(30);
        static TennisGame game;
    }

    class when_player1_has_30_and_scores
    {
        Establish context = () =>
        {
            game = new TennisGame(new PlayerScore(2), new PlayerScore(0));
        };

        Because of = () => game.Player1Scores();

        It should_announce_40_for_player_1 = () => game.Player1.Score.ShouldEqual(40);
        static TennisGame game;
    }

    class when_player2_has_30_and_scores
    {
        Establish context = () =>
        {
            game = new TennisGame(new PlayerScore(0), new PlayerScore(2));
        };

        Because of = () => game.Player2Scores();

        It should_announce_40_for_player_2 = () => game.Player2.Score.ShouldEqual(40);
        static TennisGame game;
    }

    class when_game_begins_and_player_1_has_scores_4_times
    {
        Establish context = () =>
        {
            game = new TennisGame();
        };

        Because of = () =>
        {
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
        };

        It should_player_1_wins = () =>
            {
                game.Player1Wins.ShouldBeTrue();
            };

        static TennisGame game;
    }
}