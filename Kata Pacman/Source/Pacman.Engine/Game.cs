using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman.Engine
{
	class Game
	{
		readonly IControllerDevice _controllerDevice;
		Pacman _pacman;
		bool isRunning = true;

		public Game(IControllerDevice controllerDevice)
		{
			_controllerDevice = controllerDevice;

			InitializeGame();
		}

		void InitializeGame()
		{
			_pacman = new Pacman();
			_controllerDevice.Hoch = () => _pacman.Blickrichtung = Blickrichtungen.NachOben;
			_controllerDevice.Runter = () => _pacman.Blickrichtung = Blickrichtungen.NachUnten;
			_controllerDevice.Links = () => _pacman.Blickrichtung = Blickrichtungen.NachLinks;
			_controllerDevice.Rechts = () => _pacman.Blickrichtung = Blickrichtungen.NachRechts;
		}

		public void Run()
		{
			while (isRunning)
			{
				// Magic um Position zu ermitteln
				var currentPacmanPosition = _pacman.Position;

				var newPacmanPosition = MoveEngine.ComputeNextPacmanPosition(currentPacmanPosition);

				_pacman.BewegeNach(newPacmanPosition);
				_pacman.Blickrichtung = Spielsteuerung.AktuelleRichtung;
			}
		}

		internal class Spielsteuerung
		{
			public Spielsteuerung()
			{
			}

			public static Blickrichtungen AktuelleRichtung { get; private set; }
		}
	}

	internal class MoveEngine
	{
		public static Position ComputeNextPacmanPosition(Position currentPacmanPosition)
		{
			throw new NotImplementedException();
		}
	}

	internal interface IControllerDevice
	{
		Action Hoch { get; set; }
		Action Runter { get; set; }
		Action Links { get; set; }
		Action Rechts { get; set; }
	}

	internal class Pacman
	{
		public Pacman()
		{
			
		}

		public void BewegeNach(Position position)
		{
			Position = position;
		}

		public Position Position { get; private set; }
		public Blickrichtungen Blickrichtung { get; set; }
	}

	internal enum Blickrichtungen
	{
		NachOben,
		NachUnten,
		NachLinks,
		NachRechts
	}

	internal class Position
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
