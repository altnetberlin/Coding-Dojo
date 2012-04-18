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
            ActivateItem(IoC.Get<GameViewModel>());
        }

        public void ShowStart()
        {
            ActivateItem(IoC.Get<StartViewModel>());
        }

        public void Quit()
        {
            Application.Current.Shutdown();
        }

        public void Continue()
        {
            ActivateItem(IoC.Get<StartViewModel>());
        }

        public void ShowHighScore()
        {
            ActivateItem(IoC.Get<HighScoreViewModel>());
        }
    }
}
