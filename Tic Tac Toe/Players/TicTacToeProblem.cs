using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class TicTacToeProblem : IProblem<GameBoard, Tuple<int, int>>
    {
        public GameBoard problem { get; set; }
        private int playerID;
        private int opponentID;

        public TicTacToeProblem(GameBoard problem, int playerID)
        {
            this.problem = problem;
            this.playerID = playerID;

            if (playerID.Equals(1))
                opponentID = 2;
            else
                opponentID = 1;
        }

        public GameBoard GetProblem(GameBoard problem)
        {
            return new GameBoard(problem);
        }

        public List<Tuple<int, int>> GetPossibleMoves(GameBoard problem)
        {
            return problem.GetEmptyFields();
        }

        public void Player1Move(GameBoard problem, Tuple<int, int> move)
        {
            problem.Move(move.Item1, move.Item2, opponentID);
        }

        public void Player2Move(GameBoard problem, Tuple<int, int> move)
        {
            problem.Move(move.Item1, move.Item2, playerID);
        }

        public int CheckWinner(GameBoard problem)
        {
            return problem.CheckWinner();
        }

        public int GetWinnerScore(int winner, bool machineMove, int depth)
        {
            int me = machineMove
            ? playerID
            : opponentID;

            return winner == me
                ? 10 - depth
                : -10 + depth;
        }
    }
}
