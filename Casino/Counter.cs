using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Counter
    {

        public void CountPointsForIndividualPlayers(List<Player> players){

            // TODO: check which player has more cards
            if (players.Count > 2 || (players.Count == 2 && players.SelectMany(p => p.CapturedCards)
                                                                   .Count() != (int)General.TotalCards / 2))
            {
                Player player = players.Where(p => (int)General.TotalCards / p.CapturedCards.Count > 
                                                   (int)General.TotalCards / p.CapturedCards.Count).FirstOrDefault();    
            }
        }
    }
}
