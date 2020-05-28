using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class GameBoard
    {
        public int rows;
        public int columns;
        public int winingSeriesCount;

        public int[,] board;
        public int turnCount;

        public GameBoard()
        {
            rows = 3;
            columns = 3;
            winingSeriesCount = 3;
            board = new int[rows, columns];
        }

        public GameBoard(int rows, int columns, int winingSeriesCount)
        {
            this.rows = rows;
            this.columns = columns;
            this.winingSeriesCount = winingSeriesCount;

            board = new int[rows, columns];
        }

        public GameBoard(GameBoard gameBoard)
        {
            rows = gameBoard.rows;
            columns = gameBoard.columns;
            winingSeriesCount = gameBoard.winingSeriesCount;

            board = CopyTable(gameBoard);
            turnCount = gameBoard.turnCount;
        }

        private int[,] CopyTable(GameBoard gameBoard)
        {
            int[,] newBoard = new int[gameBoard.board.GetLength(0), gameBoard.board.GetLength(1)];

            for (int i = 0; i < newBoard.GetLength(0); i++)
            {
                for (int j = 0; j < newBoard.GetLength(1); j++)
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
            else
                throw new Exception("Bad row and colum position!");
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
            int rowsMoves = rows - winingSeriesCount + 1;
            int columnsMoves = columns - winingSeriesCount + 1;

            for (int i = 0; i < rowsMoves; i++)
            {
                for (int j = 0; j < columnsMoves; j++)
                {
                    winnerID = PartialCheckWinner(i, j);
                    if (winnerID != 0)
                        return winnerID;

                }
            }
            return winnerID;
        }

        private int PartialCheckWinner(int startRow, int startColumn)
        {
            int winnerID = 0;

            // Horizontal checks
            for (int i = startRow; i < startRow + winingSeriesCount; i++)
            {
                winnerID = board[i, startColumn];
                if (winnerID != 0)
                {
                    for (int j = startColumn; j < startColumn + winingSeriesCount; j++)
                    {
                        if (board[i, startColumn] != board[i, j])
                        {
                            winnerID = board[i, j];
                        }
                    }
                }
                if (board[i, startColumn] == winnerID && winnerID != 0)
                    return winnerID;
            }

            // Vertical checks
            for (int i = startColumn; i < startColumn + winingSeriesCount; i++)
            {
                winnerID = board[startRow, i];
                if (winnerID != 0)
                {
                    for (int j = startRow; j < startRow + winingSeriesCount; j++)
                    {
                        if (board[startRow, i] != board[j, i])
                        {
                            winnerID = board[j, i];
                        }
                    }
                }
                if (board[startRow, i] == winnerID && winnerID != 0)
                    return winnerID;
            }

            // First diagonal checks
            winnerID = board[startRow, startColumn];
            for (int i = 0; i < winingSeriesCount; i++)
            {
                if (board[startRow, startColumn] != board[startRow + i, startColumn + i])
                {
                    winnerID = board[startRow + i, startColumn + i];
                }
            }
            if (board[startRow, startColumn] == winnerID && winnerID != 0)
                return winnerID;

            // Second diagonal checks
            winnerID = board[startRow + winingSeriesCount - 1, startColumn];
            for (int i = 0; i < winingSeriesCount; i++)
            {
                if (board[startRow + winingSeriesCount - 1, startColumn] != board[(startRow + winingSeriesCount - 1 - i), startColumn + i])
                {
                    winnerID = board[startRow + winingSeriesCount - 1 - i, startColumn + i];
                }
            }
            if (board[startRow + winingSeriesCount - 1, startColumn] == winnerID && winnerID != 0)
                return winnerID;

            return 0;
        }

        public List<Tuple<int, int>> GetWinnerPositions()
        {
            List<Tuple<int, int>> winnerPositions = new List<Tuple<int, int>>();
            int rowsMoves = rows - winingSeriesCount + 1;
            int columnsMoves = columns - winingSeriesCount + 1;

            for (int i = 0; i < rowsMoves; i++)
            {
                for (int j = 0; j < columnsMoves; j++)
                {
                    foreach (var pos in PartialGetWinnerPositions(i, j))
                        winnerPositions.Add(pos);
                }
            }

            return winnerPositions;
        }

        private List<Tuple<int, int>> PartialGetWinnerPositions(int startRow, int startColumn)
        {
            List<Tuple<int, int>> winnerPositions = new List<Tuple<int, int>>();
            List<Tuple<int, int>> tmpWinnerPositions = new List<Tuple<int, int>>();

            int winnerID = 0;
            // Horizontal checks
            for (int i = startRow; i < startRow + winingSeriesCount; i++)
            {
                winnerID = board[i, startColumn];
                if (winnerID != 0)
                {
                    for (int j = startColumn; j < startColumn + winingSeriesCount; j++)
                    {
                        tmpWinnerPositions.Add(new Tuple<int, int>(i, j));
                        if (board[i, startColumn] != board[i, j])
                        {
                            winnerID = board[i, j];
                        }
                    }
                }
                if (board[i, startColumn] == winnerID && winnerID != 0)
                {
                    foreach (var el in tmpWinnerPositions)
                        winnerPositions.Add(el);
                }
                tmpWinnerPositions.Clear();
            }

            // Vertical checks
            for (int i = startColumn; i < startColumn + winingSeriesCount; i++)
            {
                winnerID = board[startRow, i];
                if (winnerID != 0)
                {
                    for (int j = startRow; j < startRow + winingSeriesCount; j++)
                    {
                        tmpWinnerPositions.Add(new Tuple<int, int>(j, i));
                        if (board[startRow, i] != board[j, i])
                        {
                            winnerID = board[j, i];
                        }
                    }
                }
                if (board[startRow, i] == winnerID && winnerID != 0)
                {
                    foreach (var el in tmpWinnerPositions)
                        winnerPositions.Add(el);
                }
                tmpWinnerPositions.Clear();
            }

            // First diagonal checks
            winnerID = board[startRow, startColumn];
            for (int i = 0; i < winingSeriesCount; i++)
            {
                tmpWinnerPositions.Add(new Tuple<int, int>(startRow + i, startColumn + i));
                if (board[startRow, startColumn] != board[startRow + i, startColumn + i])
                {
                    winnerID = board[startRow + i, startColumn + i];
                }
            }
            if (board[startRow, startColumn] == winnerID && winnerID != 0)
            {
                foreach (var el in tmpWinnerPositions)
                    winnerPositions.Add(el);
            }
            tmpWinnerPositions.Clear();

            // Second diagonal checks
            winnerID = board[startRow + winingSeriesCount - 1, startColumn];
            for (int i = 0; i < winingSeriesCount; i++)
            {
                tmpWinnerPositions.Add(new Tuple<int, int>(startRow + winingSeriesCount - 1 - i, startColumn + i));
                if (board[startRow + winingSeriesCount - 1, startColumn] != board[startRow + winingSeriesCount - 1 - i, startColumn + i])
                {
                    winnerID = board[startRow + winingSeriesCount - 1 - i, startColumn + i];
                }
            }
            if (board[startRow + winingSeriesCount - 1, startColumn] == winnerID && winnerID != 0)
            {
                foreach (var el in tmpWinnerPositions)
                    winnerPositions.Add(el);
            }
            tmpWinnerPositions.Clear();

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

        public string BoardVisualization()
        {
            string boardVisualization = "";

            for (int i = 0; i < board.GetLength(0); i++)
            {
                boardVisualization += ("[ ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (j < board.GetLength(1))
                        boardVisualization += board[i, j] + " ";
                }
                boardVisualization += "]\n";
            }
            return boardVisualization;
        }
    }
}
