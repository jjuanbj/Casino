using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Casino
{
    class Start
    {
        private Deck deck;
        private List<Player> players;
        private Table table;

        public void StartGame()
        {
            deck = new Deck();
            deck.CreateCards();
            deck.ShuffleCards();

            Console.WriteLine(English.WelcomeToCasinoGame);
            string username = "";
            players = new List<Player>();

            while (username != Keyboard.F && username != Keyboard.f)
            {
                Console.WriteLine(English.PleaseWritePlayerNamesPressFWhenFinished);
                username = Console.ReadLine().Trim();

                if (username != Keyboard.F && username != Keyboard.f)
                {
                    if (username != English.Computer)
                    {
                        players.Add(new Player(username));
                    }
                    else if (username == English.Computer)
                    {
                        Console.WriteLine(English.ThisNameIsNotAllowed);
                    }
                }
            }

            players.Add(new Player(English.Computer));

            Console.WriteLine(string.Format(English.Welcome + ": {0}."
                , string.Join(", ", players.Select(j => j.Name))));

            table = new Table();

            deck.DealCardsTable(table);
            deck.DealCardsPlayer(players);
        }

        public void ShowTableCards()
        {
            Console.WriteLine(string.Format(English.OnTable + ": {0}."
                , string.Join(", ", table.Cards.Select(c => new { c.Rank, c.Suit }))));
        }

        public void ShowPlayersCards()
        {
            foreach (var player in players.Where(p => p.Name != English.Computer))
            {
                Console.WriteLine(string.Format(player.Name + ": {0}."
                    , string.Join(", ", player.Cards.Select(c => new { c.Rank, c.Suit }))));
            }            
        }
    }
}
