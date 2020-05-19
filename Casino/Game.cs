using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Game
    {
        private Deck deck = new Deck();
        private List<Player> players = new List<Player>();
        private Table table = new Table();
        
        public Deck Deck { get; set; }
        public List<Player> Players { get; set; }
        public Table Table { get; set; }
        public ConsoleOutput ConsoleOutput { get; set; }

        public Game()
        {
            Deck = deck;
            Players = players;
            Table = table;
        }
    }
}
