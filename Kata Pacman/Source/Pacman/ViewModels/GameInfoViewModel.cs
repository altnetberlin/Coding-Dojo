namespace Pacman.ViewModels
{
    using Engine;

    public class GameInfoViewModel
    {
        private IPlayerInfo playerInfo;

        public GameInfoViewModel(IPlayerInfo playerInfo)
        {
            this.playerInfo = playerInfo;

            Points = 2752685;
            Lifes = 3;
            Round = 1;
        }

        public long Points
        {
            get { return this.playerInfo.Score; }
            set { this.playerInfo.Score = value; }
        }

        public int Lifes { get; set; }

        public byte Round { get; set; }
    }
}
