using System;
using System.Collections.Generic;

namespace Casino
{
    class Spanish
    {
        public string WelcomeToCasinoGame { get; private set; }

        public string PleaseWritePlayerNamesPress { get; private set; }

        public string F { get; private set; }

        public string WhenFinished { get; private set; }

        public string Welcome { get; private set; }

        public string Computer { get; private set; }

        public string ThisNameIsNotAllowed { get; private set; }

        public string ThisIsNotAnAllowedAction { get; private set; }

        public string OnTable { get; private set; }

        public string ItsYourTurn { get; private set; }

        public string SelectOneCardByIndexNumber { get; private set; }

        public string YouSelected { get; private set; }

        public string TypeValidCardNumber { get; private set; }

        public string ChooseOneAction { get; private set; }

        public string ChooseYourLanguage { get; private set; }

        public string WhichCardWouldYouLikeToTakeFromTheTable { get; set; }

        public string CapturedCards { get; set; }

        public string YourCards { get; set; }

        public string Press { get; set; }

        public string A { get; set; }

        public string IfYouWantToSelectAnotherAction { get; set; }

        public string YouJustLostYourCardBecauseItIsInvalid { get; set; }

        public string SelectYourBuildingRank { get; set; }

        public string SingleBuild { get; set; }

        public string MultipleBuild { get; set; }

        public string YouCannotThrowCardsWhenYouAreABuildingCardOwner { get; set; }

        public string IfYouDontHaveMoreMoveYouMustCaptureYourBuildingCard { get; set; }

        public string Player { get; set; }

        public string Score { get; set; }

        public string Winner { get; set; }

        public string Points { get; set; }

        public string MostCards { get; set; }

        public string MostSpades { get; set; }

        public string TenOfDiamonds { get; set; }

        public string TwoOfSpades { get; set; }

        public string AceOfDiamonds { get; set; }

        public string AceOfSpades { get; set; }

        public string AceOfHearts { get; set; }

        public string AceOfClub { get; set; }

        public string Sweep { get; set; }

        public Spanish()
        {
            WelcomeToCasinoGame = "¡Bienvenido al juego de casino!";
            PleaseWritePlayerNamesPress = "Por favor escribe el nombre de los jugadores, presiona ";
            F = "F";
            WhenFinished = " cuando termines";
            Welcome = "Bienvenido";
            Computer = "Computer";
            ThisNameIsNotAllowed = "Este nombre no está permitido.";
            ThisIsNotAnAllowedAction = "Esta no es una acción permitida";
            OnTable = "En la mesa";
            ItsYourTurn = " es tu turno!";
            SelectOneCardByIndexNumber = " selecciona una carta por su número de orden: ";
            YouSelected = "Has seleccionado: ";
            TypeValidCardNumber = "Escribe un número de carta válido.";
            ChooseOneAction = "Elige una acción: 1-Lanzar la carta sobre la mesa, 2-Tomar cartas de la mesa, 3-Combinar cartas, 4-Emparejar cartas";
            ChooseYourLanguage = "Elige tu idioma: 1- English, 2- Español";
            WhichCardWouldYouLikeToTakeFromTheTable = "¿Cuál carta deseas tomar de la mesa? ";
            CapturedCards = "Cartas capturadas: ";
            YourCards = "Tus cartas: ";
            Press = "Presiona ";
            A = "A";
            IfYouWantToSelectAnotherAction = " si quieres seleccionar otra acción.";                        
            YouJustLostYourCardBecauseItIsInvalid = "Acabas de perder tu carta porque no es válida.";
            SelectYourBuildingRank = " selecciona tu rango de combinación: ";
            SingleBuild = "Cartas combinadas";
            MultipleBuild = "Cartas emparejadas";
            YouCannotThrowCardsWhenYouAreABuildingCardOwner = "No puedes lanzar cartas cuando eres dueño de cartas combinadas o emparejadas";
            IfYouDontHaveMoreMoveYouMustCaptureYourBuildingCard = "Si no tienes más jugadas, debes capturar tu carta combinada";
            Player = "Jugador: ";
            Score = ", puntaje: ";
            Winner = "Ganador: ";
            Points = " puntos: ";
            MostCards = "Más cartas";
            MostSpades = "Más picas";
            TenOfDiamonds = "Diez de casino";
            TwoOfSpades = "Dos de picas";
            AceOfDiamonds = "As de diamantes";
            AceOfSpades = "As de picas";
            AceOfHearts = "As de corazones";
            AceOfClub = "As de flores";
            Sweep = "Virado";
        }
    }
}
