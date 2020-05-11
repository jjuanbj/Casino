using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Casino
{
    class Card
    {
        [Display(Name = "Card Name")]
        public string CardName { get; set; }        
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            CardName = rank.ToString() + " of " + suit.ToString();            

            Rank = rank;

            Suit = suit;
        }

        public Card(string cardName)
        {
            CardName = cardName;

            Rank = (Rank)Enum.Parse(typeof(Rank), cardName.Split(' ').First(), true);

            Suit = (Suit)Enum.Parse(typeof(Suit), cardName.Split(' ').Last(), true);
        }
    }
}
