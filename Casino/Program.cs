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
            deck.CreateCards();
            deck.ShuffleCards();

            Console.WriteLine(English.WelcomeToCasinoGame);
            string username = "";
            List<Player> players = new List<Player>();

            while (username != Keyboard.F && username != Keyboard.f)
            {
                Console.WriteLine(English.PleaseWritePlayerNamesPressFWhenFinished);
                username = Console.ReadLine();

                if (username != Keyboard.F && username != Keyboard.f)
                {
                    players.Add(new Player(username));
                }
            }

            Console.WriteLine(string.Format(English.Welcome + ": {0}.", string.Join(", ", players.Select(j => j.Name))));

            var table = new Table();

            deck.DealCardsTable(table);
            deck.DealCardsPlayer(players);
        }
    }
}
