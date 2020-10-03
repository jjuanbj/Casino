using System;
using System.Collections.Generic;

namespace Casino {

    class BuildedCard {

        public List<Card> BuildedCards { get; set; }

        public Rank BuildedCardsRank { get; set; }

        //TODO: indicate if a build is pair or combination
        public bool IsPair { get; set; }
    }
}