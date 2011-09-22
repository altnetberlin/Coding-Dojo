using Machine.Specifications;

namespace KataTennis
{
    public class with_game
    {
        internal static Player _player1;
        internal static Player _player2;
        internal static Umpire _umpire;

        Establish context = () =>
            {
                _player1 = new Player {Name = "Player 1"};
                _player2 = new Player {Name = "Player 2"};
                _umpire = new Umpire(_player1, _player2);
            };
    }

    [Subject("Game")]
    public class when_player1_wins_a_ball_with_score_0 : with_game
    {
        Because of = () => { _player1.WinsBall(); };

        It should_raise_score_to_1 = () => { _player1.Score.ShouldEqual(1); };
    }

    public class when_player1_wins_a_ball_with_score_1 : with_game
    {
        Establish context = () =>_player1.Score = 1;

        Because of = () => { _player1.WinsBall(); };

        It should_raice_score_to_2 = () => { _player1.Score.ShouldEqual(2); };
    }

    public class when_player1_wins_a_ball_with_score_2 : with_game
    {
        Establish context = () =>
                            _player1.Score = 2;

        Because of = () => { _player1.WinsBall(); };

        It should_raice_score_to_3 = () => { _player1.Score.ShouldEqual(3); };
    }

    public class when_player1_wins_a_ball_with_score_3_and_player2_has_less_than_3 : with_game
    {
        Establish context = () =>
            {
                _player1.Score = 3;
                _player2.Score = 2;
            };

        Because of = () => { _player1.WinsBall(); };

        It should_raice_score_to_5 = () => { _player1.Score.ShouldEqual(5); };
    }

    public class when_player1_wins_a_ball_with_score_3_and_player2_has_score_3 : with_game
    {
        Establish context = () =>
            {
                _player1.Score = 3;
                _player2.Score = 3;
            };

        Because of = () => { _player1.WinsBall(); };

        It should_raice_score_to_4 = () => { _player1.Score.ShouldEqual(4); };
    }

    public class when_player1_wins_a_ball_with_score_3_and_player2_has_score_4 : with_game
    {
        Establish context = () =>
            {
                _player1.Score = 3;
                _player2.Score = 4;
            };

        Because of = () => { _player1.WinsBall(); };

        It player1_should_have_score_3 = () => { _player1.Score.ShouldEqual(3); };

        It player2_should_have_score_3 = () => { _player2.Score.ShouldEqual(3); };
    }
}