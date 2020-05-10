using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Console.WriteLine(string.Format(player.Name + " select one card by index number: " + "{0}.", string.Join(", ", player.Cards.Select((c, count) => new { Index = count, c.CardName}))));

            string cardNumber = Console.ReadLine().Trim();

            if (!String.IsNullOrEmpty(cardNumber) 
                && cardNumber.All(char.IsDigit) 
                && Enumerable.Range((int)General.Zero, player.Cards.Count).Contains(Int32.Parse(cardNumber)))
            {
                Console.WriteLine("You selected: " + player.Cards.ElementAt(Int32.Parse(cardNumber)).CardName);                
            }
            else
            {
                Console.WriteLine("False");
            }                       
        }
    }
}
