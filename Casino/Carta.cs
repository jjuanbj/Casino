using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Carta
    {
        public TipoCartas Tipo { get; set; }
        public ValorCartas Valor { get; set; }

        public Carta(TipoCartas tipoCartas, ValorCartas valorCartas)
        {
            Tipo = tipoCartas;

            Valor = valorCartas;
        }
    }
}
