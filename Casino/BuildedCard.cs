using System;
using System.Collections.Generic;

namespace Casino {

    class BuildedCard {

        public string Name { get; set; }

        public List<Card> BuildedCards { get; set; }

        public Rank BuildedCardsRank { get; set; }
        
        public bool IsMultiple { get; set; }

        public String Owner { get; set; }
    }
}