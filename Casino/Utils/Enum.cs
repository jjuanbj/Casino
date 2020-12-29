using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Casino
{
    enum Suit
    {
        // TODO: change displaying to: ♥, ♠, ♦, ♣
        Heart, Spade, Diamond, Club
    }

    enum Rank
    {
        Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }

    enum General
    {
        TotalCards = 52,
        NumberCardsToDeal = 4,
        Zero = 0
    }

    enum Points
    {
        [Display(Name = "Most cards")]
        MostCards = 3,
   
        [Display(Name = "Most spades")]
        MostSpades = 1,

        [Display(Name = "Ten of diamonds")]
        TenOfDiamonds = 2, 

        [Display(Name = "Two of spades")]
        TwoOfSpades = 1,

        [Display(Name = "Ace of diamonds")] 
        AceOfDiamonds = 1,

        [Display(Name = "Ace of spades")]
        AceOfSpades = 1,

        [Display(Name = "Ace of hearts")]
        AceOfHearts = 1,

        [Display(Name = "Ace of clubs")]
        AceOfClubs = 1,

        [Display(Name = "Sweep")]
        Sweep = 1
    }
}
