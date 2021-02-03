namespace Casino
{
    static class CardUtils{

        public static string CreateRankName(Rank rank){

            string name = null;

            switch (rank)
            {
                case Rank.Ace:
                    name = "A";
                    break;
                case Rank.Two:
                    name = "2";
                    break;
                case Rank.Three:
                    name = "3";
                    break;
                case Rank.Four:
                    name = "4";
                    break;
                case Rank.Five:
                    name = "5";
                    break;
                case Rank.Six:
                    name = "6";
                    break;
                case Rank.Seven:
                    name = "7";
                    break;
                case Rank.Eight:
                    name = "8";
                    break;
                case Rank.Nine:
                    name = "9";
                    break;
                case Rank.Ten:
                    name = "10";
                    break;
                case Rank.Jack:
                    name = "J";
                    break;
                case Rank.Queen:
                    name = "Q";
                    break;
                case Rank.King:
                    name = "K";
                    break;
            }

            return name;
        }
    }
}