using System;
using System.Collections.Generic;

namespace CPE_U3_Sistema_de_registro_de_jugadores_y_equipos
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public HashSet<string> Jugadores { get; set; }

        public Equipo(string nombre)
        {
            Nombre = nombre;
            Jugadores = new HashSet<string>();
        }

        public void AgregarJugador(string jugador)
        {
            if (Jugadores.Add(jugador))
            {
                Console.WriteLine($"Jugador '{jugador}' inscrito en el equipo '{Nombre}'.");
            }
            else
            {
                Console.WriteLine($"El jugador '{jugador}' ya está inscrito en el equipo '{Nombre}'.");
            }
        }
    }
}