using System;
using System.Collections.Generic;
namespace Connect4.Components
{
    public class Game
    {
        private const int _defaultBoardHeight = 6;
        private const int _defaultBoardWidth = 7;
        private const int _defaultWinningLength = 4;

        public int CurrentPlayer { get; private set; }
        public int? Winner { get; private set; }
        public int[,] Board { get; private set; }
        public int BoardHeight { get; private set; }
        public int BoardWidth { get; private set; }
        public int WinningLength { get; private set; }
        public string ErrorMessage { get; private set; }

        public Game() : this(6, 7, 4) {}

        public Game(int height, int width, int winningLength)
        {
            CurrentPlayer = 1;
            BoardWidth = width;
            BoardHeight = height;
            WinningLength = winningLength;
            Board = new int[BoardWidth, BoardHeight];
        }

        public void DropPiece(int column) {
            ErrorMessage = string.Empty;

            if (column < 0 || column >= BoardWidth) {
                ErrorMessage = "Piece dropped off board.";
                return;
            }

            if (Board[column, BoardHeight - 1] != 0) {
                ErrorMessage = "Piece dropped in full column.";
                return;
            }

            for (var i = 0; i < BoardHeight; i ++) {
                if (Board[column, i] == 0)
                {
                    Board[column, i] = CurrentPlayer;
                    break;
                }
            }

            UpdateGameStatus();
            if (Winner == null)
                CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;
        }

        public void UpdateGameStatus() {
            if (CheckHorizontal() || CheckVertical() || CheckDiagonalUp() || CheckDiagonalDown())
                Winner = CurrentPlayer;
            else {
                var spotsRemain = false;
				for (var row = 0; row < BoardHeight; row++)
				{
					for (var column = 0; column < BoardWidth; column++)
					{
                        spotsRemain = Board[column, row] == 0;
					}
				}

                if (!spotsRemain)
                    Winner = -1;
            }


        }

        private bool CheckHorizontal() {
            for (var row = 0; row < BoardHeight; row++)
            {
                for (var column = 0; column < (BoardWidth - WinningLength); column++)
                {
                    var won = true;
                    for (var i = 0; i < WinningLength; i++)
                        won = won && Board[column + i, row] == CurrentPlayer;

                    if (won) 
                        return true;                    
                }
            }

            return false;
        }

		private bool CheckVertical()
		{
			for (var column = 0; column < BoardWidth; column++)
			{
		    	for (var row = 0; row < BoardHeight - WinningLength; row++)
				{
					var won = true;
					for (var i = 0; i < WinningLength; i++)
						won = won && Board[column, row + i] == CurrentPlayer;

					if (won)
						return true;
				}
			}

			return false;
		}

        private bool CheckDiagonalUp() {
			for (var column = 0; column < BoardWidth - WinningLength; column++)
			{
				for (var row = WinningLength - 1; row < BoardHeight; row++)
				{
					var won = true;
					for (var i = 0; i < WinningLength; i++)
						won = won && Board[column + i, row - i] == CurrentPlayer;

					if (won)
						return true;
				}
			}

            return false;
        }

		private bool CheckDiagonalDown()
		{
			for (var column = 0; column < BoardWidth - WinningLength; column++)
			{
				for (var row = 0; row < BoardHeight - WinningLength; row++)
				{
					var won = true;
					for (var i = 0; i < WinningLength; i++)
						won = won && Board[column + i, row + i] == CurrentPlayer;

					if (won)
						return true;
				}
			}

			return false;
		}
    }
}

