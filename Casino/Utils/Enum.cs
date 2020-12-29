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
        MostCards,
   
        [Display(Name = "Most spades")]
        MostSpades,

        [Display(Name = "Ten of diamonds")]
        TenOfDiamonds, 

        [Display(Name = "Two of spades")]
        TwoOfSpades,

        [Display(Name = "Ace of diamonds")] 
        AceOfDiamonds,

        [Display(Name = "Ace of spades")]
        AceOfSpades,

        [Display(Name = "Ace of hearts")]
        AceOfHearts,

        [Display(Name = "Ace of clubs")]
        AceOfClubs,

        [Display(Name = "Sweep")]
        Sweep
    }
}
