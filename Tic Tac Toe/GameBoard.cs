using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class GameBoard
    {
        public int[,] board = new int[3, 3];
        public int turnCount;

        public GameBoard()
        {

        }

        public GameBoard(GameBoard gameBoard)
        {
            board = CopyTable(gameBoard);
            turnCount = gameBoard.turnCount;
        }

        private int[,] CopyTable(GameBoard gameBoard)
        {
            int[,] newBoard = new int[3, 3];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    newBoard[i, j] = gameBoard.board[i, j];
                }
            }
            return newBoard;
        }

        public void Move(int row, int column, int playerID)
        {
            if (row <= board.GetLength(0) && column <= board.GetLength(1))
            {
                board[row, column] = playerID;
                turnCount++;
            }
        }

        public bool IsPlayer1Turn()
        {
            if (turnCount % 2 == 0)
                return true;
            else
                return false;
        }

        public bool IsPlayer2Turn()
        {
            if (turnCount % 2 != 0)
                return true;
            else
                return false;
        }

        public List<Tuple<int, int>> GetEmptyFields()
        {
            List<Tuple<int, int>> emptyFields = new List<Tuple<int, int>>();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].Equals(0))
                    {
                        emptyFields.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return emptyFields;
        }

        public int CheckWinner()
        {
            int winnerID = 0;

            // Horizontal checks
            if ((board[0, 0] == board[0, 1]) && (board[0, 1] == board[0, 2]) && (!board[0, 0].Equals(0)))
                winnerID = board[0, 0];
            if ((board[1, 0] == board[1, 1]) && (board[1, 1] == board[1, 2]) && (!board[1, 0].Equals(0)))
                winnerID = board[1, 0];
            if ((board[2, 0] == board[2, 1]) && (board[2, 1] == board[2, 2]) && (!board[2, 0].Equals(0)))
                winnerID = board[2, 0];

            // Vertical checks
            if ((board[0, 0] == board[1, 0]) && (board[1, 0] == board[2, 0]) && (!board[0, 0].Equals(0)))
                winnerID = board[0, 0];
            if ((board[0, 1] == board[1, 1]) && (board[1, 1] == board[2, 1]) && (!board[0, 1].Equals(0)))
                winnerID = board[0, 1];
            if ((board[0, 2] == board[1, 2]) && (board[1, 2] == board[2, 2]) && (!board[0, 2].Equals(0)))
                winnerID = board[0, 2];

            // Diagonal checks
            if ((board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2]) && (!board[0, 0].Equals(0)))
                winnerID = board[0, 0];
            if ((board[0, 2] == board[1, 1]) && (board[1, 1] == board[2, 0]) && (!board[0, 2].Equals(0)))
                winnerID = board[0, 2];

            return winnerID;
        }

        public List<Tuple<int, int>> GetWinnerPositions()
        {
            List<Tuple<int, int>> winnerPositions = new List<Tuple<int, int>>();

            // Horizontal checks
            if ((board[0, 0] == board[0, 1]) && (board[0, 1] == board[0, 2]) && (!board[0, 0].Equals(0)))
            {
                winnerPositions.Add(new Tuple<int, int>(0, 0));
                winnerPositions.Add(new Tuple<int, int>(0, 1));
                winnerPositions.Add(new Tuple<int, int>(0, 2));
            }
            if ((board[1, 0] == board[1, 1]) && (board[1, 1] == board[1, 2]) && (!board[1, 0].Equals(0)))
            {
                winnerPositions.Add(new Tuple<int, int>(1, 0));
                winnerPositions.Add(new Tuple<int, int>(1, 1));
                winnerPositions.Add(new Tuple<int, int>(1, 2));
            }
            if ((board[2, 0] == board[2, 1]) && (board[2, 1] == board[2, 2]) && (!board[2, 0].Equals(0)))
            {
                winnerPositions.Add(new Tuple<int, int>(2, 0));
                winnerPositions.Add(new Tuple<int, int>(2, 1));
                winnerPositions.Add(new Tuple<int, int>(2, 2));
            }

            // Vertical checks
            if ((board[0, 0] == board[1, 0]) && (board[1, 0] == board[2, 0]) && (!board[0, 0].Equals(0)))
            {
                winnerPositions.Add(new Tuple<int, int>(0, 0));
                winnerPositions.Add(new Tuple<int, int>(1, 0));
                winnerPositions.Add(new Tuple<int, int>(2, 0));
            }
            if ((board[0, 1] == board[1, 1]) && (board[1, 1] == board[2, 1]) && (!board[0, 1].Equals(0)))
            {
                winnerPositions.Add(new Tuple<int, int>(0, 1));
                winnerPositions.Add(new Tuple<int, int>(1, 1));
                winnerPositions.Add(new Tuple<int, int>(2, 1));
            }
            if ((board[0, 2] == board[1, 2]) && (board[1, 2] == board[2, 2]) && (!board[0, 2].Equals(0)))
            {
                winnerPositions.Add(new Tuple<int, int>(0, 2));
                winnerPositions.Add(new Tuple<int, int>(1, 2));
                winnerPositions.Add(new Tuple<int, int>(2, 2));
            }

            // Diagonal checks
            if ((board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2]) && (!board[0, 0].Equals(0)))
            {
                winnerPositions.Add(new Tuple<int, int>(0, 0));
                winnerPositions.Add(new Tuple<int, int>(1, 1));
                winnerPositions.Add(new Tuple<int, int>(2, 2));
            }
            if ((board[0, 2] == board[1, 1]) && (board[1, 1] == board[2, 0]) && (!board[0, 2].Equals(0)))
            {
                winnerPositions.Add(new Tuple<int, int>(0, 2));
                winnerPositions.Add(new Tuple<int, int>(1, 1));
                winnerPositions.Add(new Tuple<int, int>(2, 0));
            }

            return winnerPositions;
        }

        public void Reset()
        {
            ResetBoard();
            turnCount = 0;
        }

        public void ResetBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }
            }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (j < board.GetLength(1))
                        Console.Write(board[i, j] + " ");
                }
                Console.WriteLine("]");
            }
        }
    }
}
