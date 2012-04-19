namespace Pacman.ViewModels
{
    using System.Windows;
    using System.Windows.Input;
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

        public void Move(KeyEventArgs args)
        {
            switch (args.Key)
            {
                case Key.Down:

                    break;

                case Key.Up:
                    break;

                case Key.Left:
                    break;

                case Key.Right:
                    break;


            }
        }
    }
}
