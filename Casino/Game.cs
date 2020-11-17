using System;
using System.Collections.Generic;

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

        public void ExcecuteGame(Game game){
            Turn turn = new Turn();
            turn.TurnToPlay(game);
        }
    }
}
