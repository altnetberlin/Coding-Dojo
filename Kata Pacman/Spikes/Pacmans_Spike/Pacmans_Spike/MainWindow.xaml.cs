using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pacmans_Spike
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		SquareViewModel _figur;

		public MainWindow()
		{
			InitializeComponent();
			_figur = new SquareViewModel();
			var timer = new DispatcherTimer
			            	{
			            		Interval = TimeSpan.FromMilliseconds(10)
			            	};

			timer.Tick += (s,e)=> _figur.Move();

			DataContext = _figur;
			timer.Start();	
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			
			switch(e.Key)
			{
				case Key.Down:
					_figur.Richtung =Nach.Unten;
					break;
				case Key.Up:
					_figur.Richtung = Nach.Oben;
					break;
				case Key.Right:
					_figur.Richtung = Nach.Rechts;
					break;
				case Key.Left :
					_figur.Richtung = Nach.Links;
					break;
				case Key.Space:
					_figur.Anhalten();
					break;
				case Key.W:
					_figur.LosLaufen();
					break;
			}
				
		}


	}
}
