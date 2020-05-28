using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface IProblem<T, M>
    {
        T problem { get; set; }
        T GetProblem(T problem); // Get problem variable
        List<M> GetPossibleMoves(T problem); // List all possible moves
        void Player1Move(T problem, M move); // Player 1 action
        void Player2Move(T problem, M move); // Player 2 action
        int CheckWinner(T problem); // Function to check who won
        int GetWinnerScore(int winner, bool machineMove, int depth); // Evaluation function
    }
}
