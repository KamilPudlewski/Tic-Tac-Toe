﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public interface IPlayer
    {
        int ID { get; set; }
        char Mark { get; set; }
        Tuple<int, int> NextMove();
    }
}
