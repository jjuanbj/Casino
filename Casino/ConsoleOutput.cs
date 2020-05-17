using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Casino
{
    class ConsoleOutput
    {
        private Speak speak = new Speak();

        public void WelcomeToCasinoGame()
        {
            Console.WriteLine(speak.WelcomeToCasinoGame);
        }

        public void PleaseWritePlayerNamesPressFWhenFinished()
        {
            Console.WriteLine(speak.PleaseWritePlayerNamesPressFWhenFinished);
        }

        public void ThisNameIsNotAllowed()
        {
            Console.WriteLine(speak.ThisNameIsNotAllowed);
        }

        public void WelcomePlayers(List<Player> players)
        {
            Console.WriteLine(string.Format(speak.Welcome + ": {0}."
                , string.Join(", ", players.Select(j => j.Name))));
        }

        public void ShowTableCards(Table table)
        {
            Console.WriteLine(string.Format(speak.OnTable + ": {0}."
                , string.Join(", ", table.Cards.Select(c => c.CardName))));
        }

        public void ShowPlayersCards(List<Player> players)
        {
            foreach (var player in players.Where(p => p.Name != speak.Computer))
            {
                Console.WriteLine(string.Format(player.Name + ": {0}."
                    , string.Join(", ", player.Cards.Select(c => c.CardName))));
            }
        }

        public void ShowPlayerCards(Player player)
        {
            Console.WriteLine(string.Format(speak.OnTable + ": {0}."
                , string.Join(", ", player.Cards.Select(c => c.CardName))));
        }

        public void SelectOneCardByIndexNumber(Player player)
        {
            Console.WriteLine(string.Format(player.Name + speak.SelectOneCardByIndexNumber + "{0}.", string.Join(", ", player.Cards.Select((c, count) => new { Index = count, c.CardName }))));
        }

        public void YouSelected(List<Card> cards, string cardNumber)
        {
            Console.WriteLine(speak.YouSelected + cards.ElementAt(Int32.Parse(cardNumber)).CardName);            
        }

        public void TypeValidCardNumber()
        {
            Console.WriteLine(speak.TypeValidCardNumber);
        }

        public void ChooseOneAction()
        {
            Console.WriteLine(speak.ChooseOneAction);
        }

        public void ChooseLanguage()
        {
            //Console.WriteLine(speak.ChooseYourLanguage);
            Console.WriteLine("Choose your language: 1- English, 2- Español");
        }

        public void ItsYourTurn(Player player)
        {
            Console.WriteLine(player.Name + speak.ItsYourTurn);
        }
    }
}
