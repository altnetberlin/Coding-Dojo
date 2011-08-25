using System.Collections.Generic;

namespace KataTennis
{
    public class PlayerScore
    {
        Dictionary<int, int> _scoreMap = new Dictionary<int, int>() { { 0, 0 }, { 1, 15 }, { 2, 30 }, { 3, 40 } };

        private int score = 0;

        public PlayerScore(int score)
        {
            this.score = score;
        }

        public int Score 
        {
            get { return _scoreMap[score]; }
        }

        public void Scores()
        {
            score++;
        }
    }
}