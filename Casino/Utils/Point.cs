using System;
using System.Collections.Generic;

namespace Casino
{
    class Point
    {
        public PointName PointName { get; set; }

        public int PointValue { get; set; }

        public Point(PointName pointName)
        {
            switch (pointName)
            {
                case PointName.AceOfClub:
                    this.PointName = PointName.AceOfClub;
                    this.PointValue = 1;
                    break;
                case PointName.AceOfDiamonds:
                    this.PointName = PointName.AceOfDiamonds;
                    this.PointValue = 1;
                    break;
                case PointName.AceOfHearts:
                    this.PointName = PointName.AceOfHearts;
                    this.PointValue = 1;
                    break;
                case PointName.AceOfSpades:
                    this.PointName = PointName.AceOfSpades;
                    this.PointValue = 1;
                    break;
                case PointName.MostCards:
                    this.PointName = PointName.MostCards;
                    this.PointValue = 3;
                    break;
                case PointName.MostSpades:
                    this.PointName = PointName.MostSpades;
                    this.PointValue = 1;
                    break;
                case PointName.TenOfDiamonds:
                    this.PointName = PointName.TenOfDiamonds;
                    this.PointValue = 2;
                    break;
                case PointName.TwoOfSpades:
                    this.PointName = PointName.TwoOfSpades;
                    this.PointValue = 1;
                    break;
                case PointName.Sweep:
                    this.PointName = PointName.Sweep;
                    this.PointValue = 1;
                    break;
            }
        }
    }
}