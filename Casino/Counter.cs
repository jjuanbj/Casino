using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Counter
    {
        private int playerCapturedCards = 0;

        private int computerCapturedCards = 0;

        private void CountMostCards(List<Player> players){
            playerCapturedCards = players.Where(p => p.Name != Constants.Computer)
                                         .FirstOrDefault().CapturedCards.Count;

            computerCapturedCards = players.Where(p => p.Name == Constants.Computer)
                                           .FirstOrDefault().CapturedCards.Count;
        }

        private void CalculatePoints(List<Player> players){

        }
        
        public void CountPoints(List<Player> players){
            
            int firstPlayerCards = players.Where(p => p.Name != Constants.Computer)
                                          .FirstOrDefault().CapturedCards.Count;

            int computerCards = players.Where(p => p.Name == Constants.Computer)
                                       .FirstOrDefault().CapturedCards.Count;

            if (firstPlayerCards > computerCards)
            {                
                players.Where(p => p.Name != Constants.Computer)
                       .FirstOrDefault().Score
                       .Add(Points.MostCards);

                if (players.Where(p => p.Name == Constants.Computer)
                           .FirstOrDefault().Score
                           .Contains(Points.MostCards))
                {
                    players.Where(p => p.Name == Constants.Computer)
                           .FirstOrDefault().Score
                           .Remove(Points.MostCards);
                }
                
                #region Test
                Console.WriteLine("Test: firstPlayerCards" + players.Where(p => p.Name != Constants.Computer)
                                                                    .FirstOrDefault().Score
                                                                    .FirstOrDefault()
                                                                    .ToString());
                #endregion

            } else if (firstPlayerCards < computerCards)
            {
                players.Where(p => p.Name == Constants.Computer)
                       .FirstOrDefault().Score
                       .Add(Points.MostCards);

                if (players.Where(p => p.Name != Constants.Computer)
                           .FirstOrDefault().Score
                           .Contains(Points.MostCards))
                {
                    players.Where(p => p.Name != Constants.Computer)
                           .FirstOrDefault().Score
                           .Remove(Points.MostCards);
                }

                #region Test
                Console.WriteLine("Test1: " + players.Where(p => p.Name == Constants.Computer)
                                                     .FirstOrDefault().Score
                                                     .FirstOrDefault()
                                                     .ToString());
                #endregion

            } else if (firstPlayerCards == computerCards)
            {
                if (players.SelectMany(p => p.Score)
                           .Contains(Points.MostCards))
                {                    
                    players.FirstOrDefault().Score
                           .Remove(Points.MostCards);                    
                }

                #region Test
                Console.WriteLine("Prueba2: " + players.Any(p => p.Score
                                                       .Contains(Points.MostCards)));
                #endregion
            }
        }
    }
}
