using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MiniMax<T, M>
    {
        IProblem<T, M> problem;

        public MiniMax(IProblem<T, M> problem)
        {
            this.problem = problem;
        }

        public M NextMove()
        {
            M bestMove = default(M);
            int bestScore = int.MinValue;

            List<M> emptyFields = problem.GetPossibleMoves(problem.problem);
            if (emptyFields.Count == 0)
                return default(M);

            for (int i = 0; i < emptyFields.Count; i++)
            {
                T newBoard = problem.GetProblem(problem.problem);
                problem.Player2Move(newBoard, emptyFields[i]);
                int score = -MiniMaxAlgorithm(newBoard, machineMove: false, depth: 0);
                //Console.WriteLine("Field: {" + emptyFields[i] + "}   Score:" + score);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = emptyFields[i];
                }
            }

            if (bestMove.Equals(default(M)))
                throw new Exception("Error!");

            return bestMove;
        }

        private int MiniMaxAlgorithm(T board, bool machineMove, int depth)
        {
            int winner = problem.CheckWinner(board);
            if (winner != 0)
                return problem.GetWinnerScore(winner, machineMove, depth);

            List<M> emptyFields = problem.GetPossibleMoves(board);

            // Draw
            if (emptyFields.Count.Equals(0))
                return 0;

            int maxScore = int.MinValue;

            for (int i = 0; i < emptyFields.Count; i++)
            {
                T newBoard = problem.GetProblem(board);

                if (machineMove.Equals(false))
                    problem.Player1Move(newBoard, emptyFields[i]);
                else
                    problem.Player2Move(newBoard, emptyFields[i]);

                int score = -MiniMaxAlgorithm(newBoard, !machineMove, depth + 1);

                if (score > maxScore)
                    maxScore = score;
            }

            return maxScore;
        }
    }
}
