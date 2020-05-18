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
            start.ChooseLanguage();
            ConsoleOutput consoleOutput = new ConsoleOutput(start.Speak);

            Deck deck = new Deck();
            List<Player> players = new List<Player>();
            Table table = new Table();
            
            start.StartGame(deck, players, table, consoleOutput);            
            
            Turn turn = new Turn();
            turn.TurnToPlay(players, table, consoleOutput);
        }
    }
}
