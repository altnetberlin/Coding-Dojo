namespace Pacman.ViewModels
{
    using Caliburn.Micro;

    public class StartViewModel : Screen
    {
        public string PlayerName { get; set; }

        protected IConductor Conductor
        {
            get { return (IConductor)Parent; }
        }
    }
}
