using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FunctionalTennis
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void T()
        {
            Assert.AreEqual(Tuple.Create(0, 0), Game.Start());
        }
    }

    public class Game
    {
        public static object Start()
        {
            return Tuple.Create(0, 0);
        }
    }
}
