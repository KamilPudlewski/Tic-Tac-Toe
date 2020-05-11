using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class Randomly : IPlayer
    {
        public int ID { get; set; }
        public char Mark { get; set; }

        GameBoard gameBoard;
        Random random = new Random();

        public Randomly(GameBoard gameBoard, int ID, char Mark)
        {
            if (ID == 0)
                throw new Exception("Player ID cannot be set to 0!");

            this.gameBoard = gameBoard;
            this.ID = ID;
            this.Mark = Mark;
        }

        public void Move()
        {
            List<Tuple<int, int>> availableMoves = GetAvailableMoves();
            int move = random.Next(availableMoves.Count);
            gameBoard.Move(availableMoves[move].Item1, availableMoves[move].Item2, Mark);
        }

        public Tuple<int, int> NextMove()
        {
            List<Tuple<int, int>> availableMoves = GetAvailableMoves();
            int move = random.Next(availableMoves.Count);
            gameBoard.Move(availableMoves[move].Item1, availableMoves[move].Item2, ID);
            return availableMoves[move];
        }

        public List<Tuple<int, int>> GetAvailableMoves()
        {
            List<Tuple<int,int>> availableMoves = new List<Tuple<int, int>>();
            for (int i = 0; i < gameBoard.board.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.board.GetLength(1); j++)
                {
                    if (gameBoard.board[i, j].Equals(0))
                        availableMoves.Add(new Tuple<int, int>(i, j));
                }
            }
            return availableMoves;
        }
    }
}
