using System;
using System.Collections.Generic;

namespace Casino
{
    class Game
    {
        public Deck Deck { get; set; }
        public List<Player> Players { get; set; }
        public Table Table { get; set; }
        public ConsoleOutput ConsoleOutput { get; set; }
        public Counter Counter { get; set; }

        public Game()
        {
            Deck = new Deck(); 
            Players = new List<Player>(); 
            Table = new Table(); 
            Counter = new Counter(); 
        }

        public void ExcecuteGame(Game game){
            Turn turn = new Turn();
            turn.TurnToPlay(game);
        }
    }
}
