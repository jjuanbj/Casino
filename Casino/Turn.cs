using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Casino
{
    class Turn
    {
        public void TurnToPlay(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine(player.Name + English.ItsYourTurn);

                if (player.Name != English.Computer)
                {
                    SelectYourCard(player);
                }
            }
        }

        private void SelectYourCard(Player player)
        {
            Console.WriteLine(string.Format(player.Name + " select one card by index number: " + "{0}."
                , string.Join(", ", player.Cards.Select((c, count) => new { Index = count, c.Rank, c.Suit}))));
        }
    }
}
