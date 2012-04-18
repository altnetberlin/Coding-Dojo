namespace Pacman.ViewModels
{
    using Engine;
    using Microsoft.Practices.Unity;

    public class GameViewModel
    {
        public GameViewModel(GameInfoViewModel gameInfo, MazeViewModel maze, IPlayerInfo playerInfo)
        {
            GameInfo = gameInfo;
            Maze = maze;

            playerInfo.Score = 1234;
        }

        public GameInfoViewModel GameInfo { get; set; }

        public MazeViewModel Maze { get; set; }
    }
}
