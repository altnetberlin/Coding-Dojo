namespace Pacman.ViewModels
{
    public class GameViewModel
    {
        public GameViewModel()
        {
            GameInfo = new GameInfoViewModel();
            Maze = new MazeViewModel();
        }

        public GameInfoViewModel GameInfo { get; set; }

        public MazeViewModel Maze { get; set; }
    }
}
