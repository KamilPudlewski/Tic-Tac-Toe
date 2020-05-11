using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public class Human : IPlayer
    {
        public int ID { get; set; }
        public char Mark { get; set; }

        public Human(int ID, char Mark)
        {
            if (ID == 0)
                throw new Exception("Player ID cannot be set to 0!");

            this.ID = ID;
            this.Mark = Mark;
        }

        public void Move()
        {

        }

        public Tuple<int, int> NextMove()
        {
            throw new NotImplementedException();
        }
    }
}
