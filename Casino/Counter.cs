using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Counter
    {
        private int userCards = 0;

        private int computerCards = 0;

        // Why I need instantiate ConsoleOutput here?
        public ConsoleOutput ConsoleOutput;

        public void CountPoints(List<Player> players)
        {
            CountMostCards(players);            
            CountMostSpades(players);
            CalculateValuableCards(players);
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
                        switch (card.Suit)
                        {
                            case Suit.Club:
                                player.Score.Add(Points.AceOfClubs);
                                break;
                            case Suit.Diamond:
                                player.Score.Add(Points.AceOfDiamonds);
                                break;
                            case Suit.Heart:
                                player.Score.Add(Points.AceOfHearts);
                                break;
                            case Suit.Spade:
                                player.Score.Add(Points.AceOfSpades);
                                break;
                        }
                    } else if (card.Rank == Rank.Two && card.Suit == Suit.Spade)
                    {
                        player.Score.Add(Points.TwoOfSpades);

                    } else if(card.Rank == Rank.Ten && card.Suit == Suit.Diamond)
                    {
                        player.Score.Add(Points.TenOfDiamonds);
                    }
                }
            }
        }

        public void CalculateSweep(List<Player> players, Player player, Table table) 
        {
            if (!table.Cards.Any())
            {
                if (players.Where(p => p.Name != player.Name)
                           .Any(s => s.Score
                           .Contains(Points.Sweep)))
                {                   
                    players.RemoveAll(p => p.Score
                           .Contains(Points.Sweep));
                } else
                {
                    player.Score.Add(Points.Sweep);   
                }                
            }            
        }

        public void CountScore(List<Player> players) 
        {
            // Move to ConsoleOutput
            foreach (var player in players)
            {
                Console.WriteLine("Player: " + player.Name + ", score: " + player.Score.Count);
            }

            // Need to fix when tie
            Console.WriteLine("Winner: " + players.OrderByDescending(p => p.Score.Count).First().Name);
            //ConsoleOutput.CountScore(players);
        }
    }
}
