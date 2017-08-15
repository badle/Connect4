using NUnit.Framework;
using System;
using Connect4.Components;
namespace Connect4.Components.Tests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            var game = new Game();
			var board = new int[,] {
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0}
			};

			Assert.AreEqual(1, game.CurrentPlayer);
            Assert.AreEqual(null, game.Winner);


            board[0, 0] = 1;
            game.DropPiece(0);
            Assert.AreEqual(board, game.Board);
            Assert.AreEqual(null, game.Winner);
            Assert.AreEqual(2, game.CurrentPlayer);

			game.DropPiece(1);
            game.DropPiece(0);
            game.DropPiece(1);
            game.DropPiece(0);
            game.DropPiece(1);
            game.DropPiece(0);

            Assert.AreEqual(1, game.Winner);
		}
    }
}
