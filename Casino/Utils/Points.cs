using System;
using System.Collections.Generic;

namespace Casino
{
    class Points
    {
        public List<Point> Score { get; set; }

        public Points()
        {
            Score = new List<Point>();
            Score.Add(new Point(Constants.MOST_CARDS, 3));
            Score.Add(new Point(Constants.MOST_SPADES, 1));
            Score.Add(new Point(Constants.TEN_OF_DIAMONDS, 2));
            Score.Add(new Point(Constants.TWO_OF_SPADES, 1));
            Score.Add(new Point(Constants.ACE_OF_DIAMONDS, 1));
            Score.Add(new Point(Constants.ACE_OF_SPADES, 1));
            Score.Add(new Point(Constants.ACE_OF_CLUBS, 1));
            Score.Add(new Point(Constants.ACE_OF_HEARTS, 1));
            Score.Add(new Point(Constants.SWEEP, 1));
        }

        public class Point
        {
            public string PointName { get; set; }
            public int PointValue { get; set; }

            public Point(string pointName, int pointValue)
            {
                this.PointName = pointName;
                this.PointValue = pointValue;
            }

            public Point(string pointName)
            {
                switch (pointName)
                {
                    case Constants.ACE_OF_CLUBS:
                        this.PointName = Constants.ACE_OF_CLUBS;
                        this.PointValue = 1;
                        break;
                    case Constants.ACE_OF_DIAMONDS:
                        this.PointName = Constants.ACE_OF_DIAMONDS;
                        this.PointValue = 1;
                        break;
                    case Constants.ACE_OF_HEARTS:
                        this.PointName = Constants.ACE_OF_HEARTS;
                        this.PointValue = 1;
                        break;
                    case Constants.ACE_OF_SPADES:
                        this.PointName = Constants.ACE_OF_SPADES;
                        this.PointValue = 1;
                        break;
                    case Constants.SWEEP:
                        this.PointName = Constants.SWEEP;
                        this.PointValue = 1;
                        break;
                    case Constants.MOST_CARDS:
                        this.PointName = Constants.MOST_CARDS;
                        this.PointValue = 3;
                        break;
                    case Constants.MOST_SPADES:
                        this.PointName = Constants.MOST_SPADES;
                        this.PointValue = 1;
                        break;
                    case Constants.TEN_OF_DIAMONDS:
                        this.PointName = Constants.TEN_OF_DIAMONDS;
                        this.PointValue = 2;
                        break;
                    case Constants.TWO_OF_SPADES:
                        this.PointName = Constants.TWO_OF_SPADES;
                        this.PointValue = 1;
                        break;
                }
            }
        }
    }
}