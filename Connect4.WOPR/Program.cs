using System;
using Connect4.Components;

namespace Connect4.WOPR
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Greetings Professor Falken.");
            Console.WriteLine("Shall we play a game?");

            var game = new Game();

            while (!game.Winner.HasValue) {
				DrawBoard(game);
                if (!string.IsNullOrEmpty(game.ErrorMessage))
					Console.WriteLine($"ERROR: {game.ErrorMessage}");
                Console.WriteLine($"Player {game.CurrentPlayer}, what column shall you choose?");

                int column;
                int.TryParse(Console.ReadLine(), out column);
                if (column != 0)
                    game.DropPiece(--column);
            }
			DrawBoard(game);

            if (game.Winner == -1)
                Console.WriteLine("Strange game... the only winning strategy seems to be not to play.");
            else
			    Console.WriteLine($"Player {game.Winner}, you win.");
        }

        private static void DrawBoard(Game game)
        {
            Console.Clear();
            Console.Write("\n");
            for (var row = game.Board.GetLength(1) - 1; row >= 0; row--)
            {
                Console.Write("| ");
                for (var column = 0; column < game.Board.GetLength(0); column++)
                {
                    var tokens = new string[] { " ", "1", "2"};
                    Console.Write($"({tokens[game.Board[column, row]]}) ");
                }
                Console.Write("|\n");
            }

            Console.Write("  ");
            for (var column = 1; column <= game.Board.GetLength(0); column++)
            {
                Console.Write($" {column}  ");
            }
            Console.Write("\n");
		}
    }
}
