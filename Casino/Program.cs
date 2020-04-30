using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Maso maso = new Maso();
            maso.CrearCartas();

            Console.WriteLine("Bienvenido al juego de casino");
            string nombreUsuario = "";
            List<Jugador> jugadores = new List<Jugador>();

            while (nombreUsuario != "F" && nombreUsuario != "f")
            {
                Console.WriteLine("Por favor, escriba nombre de jugadores, presione F cuando haya finalizado");
                nombreUsuario = Console.ReadLine();

                if (nombreUsuario != "F" && nombreUsuario != "f")
                {
                    jugadores.Add(new Jugador(nombreUsuario));
                }
            }

            Console.WriteLine(string.Format("Bienvenidos: {0}.", string.Join(", ", jugadores.Select(j => j.Nombre))));

            
        }
    }
}
