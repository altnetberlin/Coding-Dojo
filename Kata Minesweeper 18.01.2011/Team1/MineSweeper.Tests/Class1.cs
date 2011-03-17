using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MineSweeper.Tests
{

    
    [TestFixture]
    public class Class1
    {
        private Spielmatrix _testMatrix1;

        [SetUp]
        public void Setup()
        {


            _testMatrix1 = new Spielmatrix();

            _testMatrix1.Felder.Add(
                new List<IFeld>
                    {
                        new Mine(),
                        new LeerFeld(),
                        new LeerFeld(),
                        new LeerFeld()

                    }
                );

            _testMatrix1.Felder.Add(
                new List<IFeld>
                    {
                        new LeerFeld(),
                        new LeerFeld(),
                        new LeerFeld(),
                        new LeerFeld()

                    }
                );

            _testMatrix1.Felder.Add(
                new List<IFeld>
                    {
                        new LeerFeld(),
                        new Mine(),
                        new LeerFeld(),
                        new LeerFeld()

                    }
                );

            _testMatrix1.Felder.Add(
                new List<IFeld>
                    {
                        new LeerFeld(),
                        new LeerFeld(),
                        new LeerFeld(),
                        new LeerFeld()

                    }
                );

        }

        [Test]
        public void Datei_soll_zu_einer_Spielmatrix_umgewandelt_werden()
        {
            string filename = "Beispiel1.txt";
            Umwandler umwandler= new Umwandler();
            Spielmatrix spielmatrix=umwandler.ErzeugeSpielmatrix(filename);

            for (int i = 0; i < 4; i++)
            {
                Assert.IsTrue(spielmatrix.Felder[i].SequenceEqual(_testMatrix1.Felder[i]));
            }
        }
    }

    public class Spielmatrix
    {
        public Spielmatrix()
        {
            Felder = new List<List<IFeld>>();
        }

        public List<List<IFeld>> Felder { get; set; }
    }

    public class Umwandler
    {
        public Spielmatrix ErzeugeSpielmatrix(string filename)
        {
            string[] dateiInhalt = System.IO.File.ReadAllLines(filename);
            var felder = new List<List<IFeld> >();
            foreach (string zeile in dateiInhalt)
            {
                var matrixZeile = new List<IFeld>();
                foreach (char c in zeile)
                {
                  matrixZeile.Add(GebeFeldTyp(c));
                }
                felder.Add(matrixZeile);
            }

            Spielmatrix m = new Spielmatrix()
                                {
                                    Felder = felder
                                };

            return m;
        }

        private IFeld GebeFeldTyp(char c)
        {
            return c.Equals('*') ? (IFeld)new Mine() : (IFeld)new LeerFeld();
        }

    }

    public interface IFeld
    {
        int Zeile { get; set; }
        int Spalte { get; set; }

    }

    public class Mine : IFeld
    {
        public int Zeile { get; set; }
        public int Spalte { get; set; }
    }

    public class LeerFeld:IFeld
    {
        public int Zeile { get; set; }
        public int Spalte { get; set; }
    } 

}
