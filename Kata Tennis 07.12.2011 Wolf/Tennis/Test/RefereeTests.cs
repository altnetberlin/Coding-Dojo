using NUnit.Framework;

namespace Tennis.Test
{
    [TestFixture]
    public class RefereeTests
    {

        [Test]
        public void AddOnePointToPlayerOneShouldReturn15()
        {
            var player1 = new Player("Boris Becker");
            var player2 = new Player("John McRow");
            var referee = new Referee(player1, player2);

            var game = new Game(referee);
            //Act
            referee.AddPointToPlayer(player1);

            Points points = referee.GetPointsOfPlayer(player1);

            Assert.AreEqual(Points.Fiveteen, points);
        }

        [Test]
        public void AddTwoPointsToPlayerOneShouldReturn30()
        {
            var player1 = new Player("Boris Becker");
            var player2 = new Player("John McRow");
            var referee = new Referee(player1, player2);

            var game = new Game(referee);
            //Act
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);

            Points points = referee.GetPointsOfPlayer(player1);

            Assert.AreEqual(Points.Thirty, points);
        }

        [Test]
        public void AddThreePointsToPlayerOneShouldReturn40()
        {
            var player1 = new Player("Boris Becker");
            var player2 = new Player("John McRow");
            var referee = new Referee(player1, player2);

            var game = new Game(referee);
            //Act
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);

            Points points = referee.GetPointsOfPlayer(player1);

            Assert.AreEqual(Points.Fourty, points);
        }

        [Test]
        public void AddFourPointsToPlayerOneShouldReturnWonPlayer1()
        {
            var player1 = new Player("Boris Becker");
            var player2 = new Player("John McRow");
            var referee = new Referee(player1, player2);

            var game = new Game(referee);
            //Act
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);

            Points points = referee.GetPointsOfPlayer(player1);

            Assert.AreEqual(Points.Win , points);
        }


        [Test]
        public void AddFourPointsToBothPlayersShouldReturnDeuce()
        {
            
            var player1 = new Player("Boris Becker");
            var player2 = new Player("John McRow");
            var referee = new Referee(player1, player2);

            var game = new Game(referee);
            //Act
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);

            referee.AddPointToPlayer(player2);
            referee.AddPointToPlayer(player2);
            referee.AddPointToPlayer(player2);

            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player2);


            Points points = referee.GetPointsOfPlayer(player1);

            Assert.AreEqual(Points.Deuce, points);
        }

        [Test]
        public void AddFourPointsToBothPlayersAndOneToPlayer1ShouldReturnAdvantage()
        {

            var player1 = new Player("Boris Becker");
            var player2 = new Player("John McRow");
            var referee = new Referee(player1, player2);

            var game = new Game(referee);
            //Act
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);

            referee.AddPointToPlayer(player2);
            referee.AddPointToPlayer(player2);
            referee.AddPointToPlayer(player2);

            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player2);

            referee.AddPointToPlayer(player1);

            Points points = referee.GetPointsOfPlayer(player1);

            Assert.AreEqual(Points.Advantage, points);
        }

        [Test]
        public void AddFourPointsToBothPlayersAndTwoToPlayer1ShouldReturnAdvantage()
        {

            var player1 = new Player("Boris Becker");
            var player2 = new Player("John McRow");
            var referee = new Referee(player1, player2);

            var game = new Game(referee);
            //Act
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);

            referee.AddPointToPlayer(player2);
            referee.AddPointToPlayer(player2);
            referee.AddPointToPlayer(player2);

            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player2);

            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);

            Points points = referee.GetPointsOfPlayer(player1);

            Assert.AreEqual(Points.Win, points);
        }

        [Test]
        public void AddFourPointsToBothPlayersAndOneToBothShouldReturnAdvantage()
        {

            var player1 = new Player("Boris Becker");
            var player2 = new Player("John McRow");
            var referee = new Referee(player1, player2);

            var game = new Game(referee);
            //Act
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player1);

            referee.AddPointToPlayer(player2);
            referee.AddPointToPlayer(player2);
            referee.AddPointToPlayer(player2);

            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player2);

            referee.AddPointToPlayer(player1);
            referee.AddPointToPlayer(player2);

            Points points = referee.GetPointsOfPlayer(player1);

            Assert.AreEqual(Points.Deuce, points);
        }
    }
}
