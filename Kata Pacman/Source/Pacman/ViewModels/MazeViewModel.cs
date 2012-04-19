namespace Pacman.ViewModels
{
    using System;
    using Caliburn.Micro;

    public class MazeViewModel : Screen
    {
		int _links;
		public int Links
		{
			get { return _links; }
			set
			{
				_links = value;
                NotifyOfPropertyChange(() => Links);
			}
		}

		int _oben;
		bool _angehalten;

		public int Oben
		{
			get { return _oben; }
			set
			{
				_oben = value;
                NotifyOfPropertyChange(() => Oben);
			}
		}

		
		public MazeViewModel()
		{
			Links = 100;
			Oben = 100;
		}

		public void Move()
		{
			if (_angehalten)
				return;
			
			switch (Richtung)
			{
				case Nach.Oben:
					Oben--;
					break;
				case Nach.Unten:
					Oben++;
					break;
				case Nach.Links:
					Links--;
					break;
				case Nach.Rechts:
					Links++;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public Nach Richtung { get; set; }

		public void Anhalten()
		{
			_angehalten = true;
		}

		public void LosLaufen()
		{
			_angehalten = false;
		}
	}

	public enum Nach
	{
		Oben,
		Unten,
		Links,
		Rechts
	}
}
