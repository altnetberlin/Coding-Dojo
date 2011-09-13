using Machine.Specifications;

namespace KataTennis
{

    public class Game
    {
        public void Start(GameScore gameScore)
        {
            CurrentScore = gameScore;
        }

        public GameScore CurrentScore { get; private set; }
    }


    [Subject(typeof(Game))]
    public class when_create_a_new_tennis_game
    {
        Establish context = () =>
            {
                _game = new Game();
            };

        Because of = () => _game.Start(new GameScore(0, 0));

        It should_have_empty_game_score = () => _game.CurrentScore.PlayerScore1.ShouldEqual(0);
        static Game _game;
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