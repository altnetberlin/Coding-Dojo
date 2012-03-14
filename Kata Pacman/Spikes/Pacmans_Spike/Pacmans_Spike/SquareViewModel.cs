using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Pacmans_Spike
{
	public class SquareViewModel:INotifyPropertyChanged 
	{
		int _links;
		public int Links
		{
			get { return _links; }
			set
			{
				_links = value;
				if (PropertyChanged != null)
					PropertyChanged(this,new PropertyChangedEventArgs("Links"));

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
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("Oben"));
			}
		}

		
		public SquareViewModel()
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

		public event PropertyChangedEventHandler PropertyChanged;

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
