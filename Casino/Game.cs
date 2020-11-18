using System;
using System.Collections.Generic;

namespace Casino
{
    class Game
    {
        private Deck deck = new Deck();
        private List<Player> players = new List<Player>();
        private Table table = new Table();
        private Counter counter = new Counter();
        public Deck Deck { get; set; }
        public List<Player> Players { get; set; }
        public Table Table { get; set; }
        public ConsoleOutput ConsoleOutput { get; set; }
        public Counter Counter { get; set; }

        public Game()
        {
            Deck = deck;
            Players = players;
            Table = table;
            Counter = counter;
        }

        public void ExcecuteGame(Game game){
            Turn turn = new Turn();
            turn.TurnToPlay(game);
        }
    }
}
