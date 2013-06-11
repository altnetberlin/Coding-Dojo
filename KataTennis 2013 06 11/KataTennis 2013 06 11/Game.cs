using System;

namespace KataTennis
{
    public class Game
    {
        public PlayerState PlayerA { get; private set; }

        public PlayerState PlayerB { get; private set; }

        public void ScoreForPlayerA()
        {
            var playerState = Score(PlayerA, PlayerB);
            PlayerA = playerState.Item1;
            PlayerB = playerState.Item2;
        }

        private Tuple<PlayerState, PlayerState> Score(PlayerState scorer, PlayerState opponent)
        {
            if (scorer == PlayerState.Winner)
                throw new InvalidOperationException();
            if (scorer != PlayerState.Forty)
                return Tuple.Create(scorer + 1, opponent);
            if (opponent == PlayerState.Advantage)
                return Tuple.Create(PlayerState.Forty, PlayerState.Forty);
            if (opponent == PlayerState.Forty)
                return Tuple.Create(PlayerState.Advantage, PlayerState.Forty);
            return Tuple.Create(PlayerState.Winner, opponent);
        }

        public void ScoreForPlayerB()
        {
            var playerState = Score(PlayerB, PlayerA);
            PlayerB = playerState.Item1;
            PlayerA = playerState.Item2;
        }
    }
}