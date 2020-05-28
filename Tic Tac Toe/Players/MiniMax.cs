using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class MiniMax : IPlayer
    {
        public int ID { get; set; }
        public char Mark { get; set; }

        private GameBoard gameBoard;

        private TicTacToeProblem ticTacToeProblem;
        private Algorithms.MiniMax<GameBoard, Tuple<int, int>> minimax;

        public MiniMax(GameBoard gameBoard, int ID, char Mark)
        {
            if (ID == 0)
                throw new Exception("Player ID cannot be set to 0!");

            this.gameBoard = gameBoard;
            this.ID = ID;
            this.Mark = Mark;

            ticTacToeProblem = new TicTacToeProblem(gameBoard, ID);
            minimax = new Algorithms.MiniMax<GameBoard, Tuple<int, int>>(ticTacToeProblem);
        }

        public Tuple<int, int> NextMove()
        {
            Tuple<int, int> bestMove = minimax.NextMove();
            gameBoard.Move(bestMove.Item1, bestMove.Item2, ID);

            return bestMove;
        }
    }
}
