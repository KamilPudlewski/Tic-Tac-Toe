using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class Human : IPlayer
    {
        public int ID { get; set; }
        public char Mark { get; set; }

        public Human(int setID, char Mark)
        {
            if (setID == 0)
                throw new Exception("Player ID cannot be set to 0!");

            this.ID = setID;
            this.Mark = Mark;
        }

        public Tuple<int, int> NextMove()
        {
            throw new NotImplementedException();
        }
    }
}
