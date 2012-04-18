namespace Pacman.ViewModels
{
    using Caliburn.Micro;
    using Engine;

    public class HighScoreViewModel : Screen
    {
        public HighScoreViewModel(IPlayerInfo playerInfo)
        {
            this.Score = playerInfo.Score;
        }

        public long Score { get; set; }
    }
}
