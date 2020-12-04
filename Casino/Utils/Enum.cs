using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Casino
{
    enum Suit
    {
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
        TenOfDiamonds = 2, 
        TwoOfSpades = 1,
        Ace = 1,
        Sweep = 1
    }
}
