using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Counter
    {
        private int userCards = 0;

        private int computerCards = 0;

        public void CountPoints(List<Player> players)
        {
            CountMostCards(players);            
            CountMostSpades(players);
        }

        private void CountMostCards(List<Player> players){

            userCards = players.Where(p => p.Name != Constants.Computer)
                               .FirstOrDefault().CapturedCards
                               .Count;

            computerCards = players.Where(p => p.Name == Constants.Computer)
                                   .FirstOrDefault().CapturedCards
                                   .Count;

            CalculatePoints(players, Points.MostCards);            
        }

        private void CountMostSpades(List<Player> players){

            if (players.Where(p => p.Name != Constants.Computer)
                       .FirstOrDefault().CapturedCards
                       .Any(c => c.Suit == Suit.Spade))
            {
                userCards = players.Where(p => p.Name != Constants.Computer)
                                   .FirstOrDefault().CapturedCards
                                   .Where(c => c.Suit == Suit.Spade)
                                   .Count();    
            }
            
            if (players.Where(p => p.Name == Constants.Computer)
                       .FirstOrDefault().CapturedCards
                       .Any(c => c.Suit == Suit.Spade))
            {
                computerCards = players.Where(p => p.Name == Constants.Computer)
                                       .FirstOrDefault().CapturedCards
                                       .Where(c => c.Suit == Suit.Spade)
                                       .Count();
            }

            CalculatePoints(players, Points.MostSpades);
        }

        private void CalculatePoints(List<Player> players, Points points){

            if (userCards > computerCards)
            {
                players.Where(p => p.Name != Constants.Computer)
                       .FirstOrDefault().Score
                       .Add(points);
                
                if (players.Where(p => p.Name == Constants.Computer)
                           .FirstOrDefault().Score
                           .Contains(points))
                {
                    players.Where(p => p.Name == Constants.Computer)
                           .FirstOrDefault().Score
                           .Remove(points);
                }
            }
            else if (userCards < computerCards)
            {
                players.Where(p => p.Name == Constants.Computer)
                       .FirstOrDefault().Score
                       .Add(points);

                if (players.Where(p => p.Name != Constants.Computer)
                           .FirstOrDefault().Score
                           .Contains(points))
                {
                    players.Where(p => p.Name != Constants.Computer)
                           .FirstOrDefault().Score
                           .Remove(points);
                }
            }
            else if (userCards == computerCards)
            {
                if (players.SelectMany(p => p.Score)
                           .Contains(points))
                {
                    players.FirstOrDefault().Score
                           .Remove(points);
                }
            }
        }

        private void CalculateValuableCards(List<Player> players)
        {
            foreach (var player in players)
            {
                foreach (var card in player.CapturedCards)
                {
                    if (card.Rank == Rank.Ace)
                    {
                        // TODO: add points to corresponding player
                        // switch (card.Suit)
                        // {
                        //     case Suit.Club:
                        //         player.Score.Add(Points.AceOfClubs);
                        //     default:
                        // }
                    }
                }
            }
        }
    }
}
