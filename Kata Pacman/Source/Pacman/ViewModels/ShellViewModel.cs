namespace Pacman.ViewModels {
    using System.Windows;
    using Caliburn.Micro;

    public class ShellViewModel : Conductor<object>, IShell
    {
        public ShellViewModel()
        {
            ShowStart();
        }

        public void StartGame()
        {
            ActivateItem(new GameViewModel());
        }

        public void ShowStart()
        {
            ActivateItem(new StartViewModel());
        }

        public void Quit()
        {
            Application.Current.Shutdown();
        }

        public void Continue()
        {
            ActivateItem(new StartViewModel());
        }

        public void ShowHighScore()
        {
            ActivateItem(new HighScoreViewModel());
        }
    }
}
