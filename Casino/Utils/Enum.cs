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

    enum PointName
    {
        MostCards, MostSpades, TwoOfSpades, TenOfDiamonds,
        AceOfClub, AceOfDiamonds, AceOfHearts, AceOfSpades,
        Sweep
    }
}
