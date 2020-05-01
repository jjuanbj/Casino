using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino
{
    class Maso
    {
        public List<Carta> Cartas { get; set; }

        public void CrearCartas()
        {            
            var valoresCartas = Enum.GetValues(typeof(ValorCartas));
            var valoresTipoCartas = Enum.GetValues(typeof(TipoCartas));

            Cartas = new List<Carta>();

            foreach (TipoCartas tipoCartas in valoresTipoCartas)
            {
                foreach (ValorCartas valorCartas in valoresCartas)
                {
                    Cartas.Add(new Carta(tipoCartas, valorCartas));
                }
            }            
        }
    }
}
