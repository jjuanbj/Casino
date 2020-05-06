using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Start start = new Start();
            start.StartGame();
            start.ShowTableCards();
            start.ShowPlayersCards();
        }
    }
}
