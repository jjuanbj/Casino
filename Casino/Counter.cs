using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Counter
    {
        private int playerCapturedCards = 0;

        private int computerCapturedCards = 0;

        public void CountPoints(List<Player> players)
        {
            CountMostCards(players);
        }

        private void CountMostCards(List<Player> players){

            playerCapturedCards = players.Where(p => p.Name != Constants.Computer)
                                         .FirstOrDefault().CapturedCards.Count;

            computerCapturedCards = players.Where(p => p.Name == Constants.Computer)
                                           .FirstOrDefault().CapturedCards.Count;

            CalculatePoints(players, Points.MostCards);
        }

        private void CalculatePoints(List<Player> players, Points points){

            if (playerCapturedCards > computerCapturedCards)
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

                #region Test
                Console.WriteLine("Test: User with most cards" + players.Where(p => p.Name != Constants.Computer)
                                                                    .FirstOrDefault().Score
                                                                    .FirstOrDefault()
                                                                    .ToString());
                #endregion

            }
            else if (playerCapturedCards < computerCapturedCards)
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

                #region Test
                Console.WriteLine("Test: computer with most cards" + players.Where(p => p.Name == Constants.Computer)
                                                     .FirstOrDefault().Score
                                                     .FirstOrDefault()
                                                     .ToString());
                #endregion

            }
            else if (playerCapturedCards == computerCapturedCards)
            {
                if (players.SelectMany(p => p.Score)
                           .Contains(points))
                {
                    players.FirstOrDefault().Score
                           .Remove(points);
                }

                #region Test
                Console.WriteLine("Test: neither have most cards" + players.Any(p => p.Score
                                                       .Contains(points)));
                #endregion
            }
        }
    }
}
