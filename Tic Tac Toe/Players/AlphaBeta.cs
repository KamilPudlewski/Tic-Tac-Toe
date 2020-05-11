using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class AlphaBeta : IPlayer
    {
        public int ID { get; set; }
        public char Mark { get; set; }

        private GameBoard gameBoard = new GameBoard();
        private int opponentID = 0;

        public AlphaBeta(GameBoard gameBoard, int ID, char Mark)
        {
            if (ID == 0)
                throw new Exception("Player ID cannot be set to 0!");

            this.gameBoard = gameBoard;
            this.ID = ID;
            this.Mark = Mark;
            SetOpponnentID();
        }

        private void SetOpponnentID()
        {
            if (ID.Equals(1))
                opponentID = 2;
            else
                opponentID = 1;
        }

        public void Move()
        {
            Console.WriteLine();
            gameBoard.PrintBoard();

            Tuple<int, int> bestMove = new Tuple<int, int>(-1, -1);
            int bestScore = int.MinValue;

            List<Tuple<int, int>> emptyFields = gameBoard.GetEmptyFields();
            if (emptyFields.Count == 0)
                return;


            for (int i = 0; i < emptyFields.Count; i++)
            {
                GameBoard newBoard = new GameBoard(gameBoard);
                newBoard.board[emptyFields[i].Item1, emptyFields[i].Item2] = ID;
                //int score = -AlphaBetaPruning(gameBoard, machineMove: false, depth: 0, -beta, -bestScore);
                int score = -StartAlphaBetaPruning(newBoard, machineMove: false, depth: 0);
                Console.WriteLine("Field: {" + emptyFields[i].Item1 + "," + emptyFields[i].Item2 + "}   Score:" + score);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = new Tuple<int, int>(emptyFields[i].Item1, emptyFields[i].Item2);
                }
            }

            if (bestMove == new Tuple<int, int>(-1, -1))
                throw new Exception("Error!");

            gameBoard.Move(bestMove.Item1, bestMove.Item2, ID);
        }

        public Tuple<int, int> NextMove()
        {
            Console.WriteLine();
            gameBoard.PrintBoard();

            Tuple<int, int> bestMove = new Tuple<int, int>(-1, -1);
            int bestScore = int.MinValue;

            List<Tuple<int, int>> emptyFields = gameBoard.GetEmptyFields();
            if (emptyFields.Count == 0)
                return null;


            for (int i = 0; i < emptyFields.Count; i++)
            {
                GameBoard newBoard = new GameBoard(gameBoard);
                newBoard.board[emptyFields[i].Item1, emptyFields[i].Item2] = ID;
                //int score = -AlphaBetaPruning(gameBoard, machineMove: false, depth: 0, -beta, -bestScore);
                int score = -StartAlphaBetaPruning(newBoard, machineMove: false, depth: 0);
                Console.WriteLine("Field: {" + emptyFields[i].Item1 + "," + emptyFields[i].Item2 + "}   Score:" + score);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = new Tuple<int, int>(emptyFields[i].Item1, emptyFields[i].Item2);
                }
            }

            if (bestMove == new Tuple<int, int>(-1, -1))
                throw new Exception("Error!");

            gameBoard.Move(bestMove.Item1, bestMove.Item2, ID);
            return bestMove;
        }

        private int StartAlphaBetaPruning(GameBoard board, bool machineMove, int depth)
        {
            const int alpha = -10;
            const int beta = 10;
            const int maxScore = alpha;

            // First call to "max" already done, so this is a call to "min"
            return AlphaBetaPruning(board, machineMove, depth, -beta, -maxScore);
        }

        private int AlphaBetaPruning(GameBoard board, bool machineMove, int depth, int alpha, int beta)
        {
            int winner = board.CheckWinner();
            if (winner != 0)
                return this.GetScoreForWinner(winner, machineMove, depth);

            List<Tuple<int, int>> emptyFields = board.GetEmptyFields();

            // Draw
            if (emptyFields.Count.Equals(0))
                return 0;

            int maxScore = alpha;
            for (int i = 0; i < emptyFields.Count; i++)
            {
                GameBoard newBoard = new GameBoard(board);
                newBoard.board[emptyFields[i].Item1, emptyFields[i].Item2] = machineMove ? ID : opponentID;
                int score = -this.AlphaBetaPruning(newBoard, !machineMove, depth + 1, -beta, -maxScore);

                if (score > maxScore)
                {
                    maxScore = score;

                    if (maxScore >= beta)
                        break;
                }
            }

            return maxScore;
        }

        private int GetScoreForWinner(int winner, bool machineMove, int depth)
        {
            int me = machineMove
                ? ID
                : opponentID;

            return winner == me
                ? 10 - depth
                : -10 + depth;
        }
    }
}
