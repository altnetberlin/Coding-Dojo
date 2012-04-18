namespace Pacman.ViewModels
{
    public class GameInfoViewModel
    {
        public GameInfoViewModel()
        {
            Points = 2752685;
            Lifes = 3;
            Round = 1;
        }

        public long Points { get; set; }

        public int Lifes { get; set; }

        public byte Round { get; set; }
    }
}
