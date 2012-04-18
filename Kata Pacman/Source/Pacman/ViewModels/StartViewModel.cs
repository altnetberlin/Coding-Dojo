namespace Pacman.ViewModels
{
    using Caliburn.Micro;
    using Engine;

    public class StartViewModel : Screen
    {
        private IPlayerInfo playerInfo;

        public StartViewModel(IPlayerInfo playerInfo)
        {
            this.playerInfo = playerInfo;
        }

        public string PlayerName
        {
            get { return this.playerInfo.Name; }
            set { this.playerInfo.Name = value; }
        }

        protected IConductor Conductor
        {
            get { return (IConductor)Parent; }
        }
    }
}
