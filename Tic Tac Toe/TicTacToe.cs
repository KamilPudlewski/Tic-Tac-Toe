using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class TicTacToe
    {
        public enum PlayerType { Human, Randomly, MiniMax, AlphaBeta }

        private GameBoard gameBoard;
        private IPlayer player1;
        private IPlayer player2;

        private Tuple<int, int> lastMove;

        private int winnerID;
        private string winnerMark;
        private bool gameOverStatus = false;
        private List<Tuple<int, int>> winnerPositions = new List<Tuple<int, int>>();

        public TicTacToe()
        {

        }

        public void SetGameBoard(int rows, int columns, int winingSeriesCount)
        {
            gameBoard = new GameBoard(rows, columns, winingSeriesCount);
        }

        public GameBoard GetGameBoard()
        {
            return gameBoard;
        }

        public void SetPlayer1(PlayerType playerType)
        {
            SetPlayerType(ref player1, playerType, 1, 'X');
        }

        public IPlayer GetPlayer1()
        {
            return player1;
        }

        public void SetPlayer2(PlayerType playerType)
        {
            SetPlayerType(ref player2, playerType, 2, 'O');
        }

        public IPlayer GetPlayer2()
        {
            return player2;
        }

        public IPlayer GetActualPlayer()
        {
            if (gameBoard.IsPlayer1Turn())
            {
                return player1;
            }
            else
            {
                return player2;
            }
        }

        public IPlayer GetNextPlayer()
        {
            if (gameBoard.IsPlayer1Turn())
            {
                return player2;
            }
            else
            {
                return player1;
            }
        }

        private void SetPlayerType(ref IPlayer player, PlayerType playerType, int playerNumber, char playerMark)
        {
            switch (playerType)
            {
                case PlayerType.Human:
                    player = new Human(playerNumber, playerMark);
                    break;
                case PlayerType.Randomly:
                    player = new Randomly(gameBoard, playerNumber, playerMark);
                    break;
                case PlayerType.MiniMax:
                    player = new MiniMax(gameBoard, playerNumber, playerMark);
                    break;
                case PlayerType.AlphaBeta:
                    player = new AlphaBeta(gameBoard, playerNumber, playerMark);
                    break;
            }
        }

        public void ResetGame()
        {
            gameBoard.Reset();
            winnerID = 0;
            winnerMark = "";
            gameOverStatus = false;
            winnerPositions.Clear();
            lastMove = null;
        }

        public bool IsHumanPlayerMove()
        {
            if (gameBoard.IsPlayer1Turn())
            {
                if (player1.GetType().Equals(typeof(Human)))
                    return true;
                else
                    return false;
            }
            else
            {
                if (player2.GetType().Equals(typeof(Human)))
                    return true;
                else
                    return false;
            }
        }

        public bool IsComputerPlayerMove()
        {
            if (gameBoard.IsPlayer1Turn())
            {
                if (!player1.GetType().Equals(typeof(Human)))
                    return true;
                else
                    return false;
            }
            else
            {
                if (!player2.GetType().Equals(typeof(Human)))
                    return true;
                else
                    return false;
            }
        }

        public void ComputerPlayerNextMove()
        {
            if (gameBoard.IsPlayer1Turn())
            {
                lastMove = player1.NextMove();
            }
            else
            {
                lastMove = player2.NextMove();
            }
            CheckWinner();
        }

        public void HumanPlayerNextMove(Tuple<int, int> move)
        {
            if (gameBoard.IsPlayer1Turn())
            {
                gameBoard.Move(move.Item1, move.Item2, player1.ID);
                lastMove = move;
            }
            else
            {
                gameBoard.Move(move.Item1, move.Item2, player2.ID);
                lastMove = move;
            }
            CheckWinner();
        }

        private void CheckWinner()
        {
            if (gameBoard.CheckWinner() != 0)
            {
                gameOverStatus = true;
                if (gameBoard.IsPlayer1Turn())
                {
                    winnerID = player2.ID;
                    winnerMark = player2.Mark.ToString();
                }
                else
                {
                    winnerID = player1.ID;
                    winnerMark = player1.Mark.ToString();
                }

                SetWinnerPositions(gameBoard.GetWinnerPositions());
            }
            else if (gameBoard.turnCount == gameBoard.rows * gameBoard.columns)
            {
                gameOverStatus = true;
                winnerID = 0;
                winnerMark = "";
            }
        }

        public Tuple<int, int> GetLastMove()
        {
            return lastMove;
        }

        public bool GetGameOverStatus()
        {
            return gameOverStatus;
        }

        public int GetWinnerID()
        {
            return winnerID;
        }

        public string GetWinnerMark()
        {
            return winnerMark;
        }

        private void SetWinnerPositions(List<Tuple<int, int>> winnerPositions)
        {
            this.winnerPositions = winnerPositions;
        }

        public List<Tuple<int, int>> GetWinnerPositions()
        {
            return winnerPositions;
        }
    }
}
