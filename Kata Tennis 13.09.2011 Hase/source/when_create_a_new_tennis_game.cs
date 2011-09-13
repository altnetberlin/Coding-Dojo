using Machine.Specifications;

namespace KataTennis
{

    public class Game
    {
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
            CurrentScore = new GameScore(CurrentScore.PlayerScore1+15, 0);
        }
    }


    [Subject(typeof(Game))]
    public class when_create_a_new_tennis_game
    {
        Establish context = () =>
            {
                _game = new Game();
            };

        Because of = () => _game.Start(new GameScore(0, 0));

        It should_player1_have_zero_points = () => _game.CurrentScore.PlayerScore1.ShouldEqual(0);
        It should_player2_have_zero_points = () => _game.CurrentScore.PlayerScore2.ShouldEqual(0);
        static Game _game;
    }

    [Subject(typeof (Game))]
    public class When_GameScore_is_Zero_to_Zero_and_Player1_scores
    {
        Establish context = () => { _game = new Game(); };

        Because of = () => { _game.Player1Scores(); };

        It should_player1_have_15_points_ = () => { _game.CurrentScore.PlayerScore1.ShouldEqual(15); };
        static Game _game;
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

        It should_player1_have_30_points_ = () => { _game.CurrentScore.PlayerScore1.ShouldEqual(30); };
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