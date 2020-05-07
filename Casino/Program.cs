using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Program
    {        
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            List<Player> players = new List<Player>();
            Table table = new Table();

            Start start = new Start();
            start.StartGame(deck, players, table);
            start.ShowTableCards(table);
            start.ShowPlayersCards(players);

            Turn turn = new Turn();
            turn.TurnToPlay(players);
        }
    }
}
