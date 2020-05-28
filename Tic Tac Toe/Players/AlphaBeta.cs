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
        public Tuple<int, int> LastMove { get; set; }

        private GameBoard gameBoard;

        private TicTacToeProblem ticTacToeProblem;
        private Algorithms.AlphaBeta<GameBoard, Tuple<int, int>> alphabeta;

        public AlphaBeta(GameBoard gameBoard, int ID, char Mark)
        {
            if (ID == 0)
                throw new Exception("Player ID cannot be set to 0!");

            this.gameBoard = gameBoard;
            this.ID = ID;
            this.Mark = Mark;

            ticTacToeProblem = new TicTacToeProblem(gameBoard, ID);
            alphabeta = new Algorithms.AlphaBeta<GameBoard, Tuple<int, int>>(ticTacToeProblem);
        }

        public Tuple<int, int> NextMove()
        {
            Tuple<int, int> bestMove = alphabeta.NextMove();
            gameBoard.Move(bestMove.Item1, bestMove.Item2, ID);
            LastMove = bestMove;

            return bestMove;
        }
    }
}
