﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Casino
{
    class Speak
    {
        public string WelcomeToCasinoGame { get; private set; }

        public string PleaseWritePlayerNamesPressFWhenFinished { get; private set; }

        public string Welcome { get; private set; }
                
        public string ThisNameIsNotAllowed { get; private set; }

        public string OnTable { get; private set; }

        public string ItsYourTurn { get; private set; }

        public string SelectOneCardByIndexNumber { get; private set; }

        public string YouSelected { get; private set; }

        public string TypeValidCardNumber { get; private set; }

        public string ChooseOneAction { get; private set; }
      
        public string ChooseYourLanguage { get; set; }
    }
}
