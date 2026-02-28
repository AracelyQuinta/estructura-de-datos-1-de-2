using System;
using System.Collections.Generic;

namespace CPE_U3_Sistema_de_registro_de_jugadores_y_equipos
{
    public class Torneo
    {
        private Dictionary<string, Equipo> equipos = new Dictionary<string, Equipo>();

        public void RegistrarEquipo(string nombreEquipo)
        {
            if (equipos.ContainsKey(nombreEquipo))
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' ya existe.");
            }
            else
            {
                equipos[nombreEquipo] = new Equipo(nombreEquipo);
                Console.WriteLine($"Equipo '{nombreEquipo}' registrado exitosamente.");
            }
        }

        public void RegistrarJugador(string nombreJugador, string nombreEquipo)
        {
            if (!equipos.ContainsKey(nombreEquipo))
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' no existe. Regístrelo primero.");
            }
            else
            {
                equipos[nombreEquipo].AgregarJugador(nombreJugador);
            }
        }

        public void MostrarEquipos()
        {
            Console.WriteLine("\n===== LISTA DE EQUIPOS =====");
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
            }
            else
            {
                foreach (var equipo in equipos.Values)
                {
                    Console.WriteLine($"- {equipo.Nombre}");
                }
            }
        }

        public void MostrarJugadores()
        {
            Console.WriteLine("\n===== LISTA DE JUGADORES =====");
            bool hayJugadores = false;

            foreach (var equipo in equipos.Values)
            {
                foreach (var jugador in equipo.Jugadores)
                {
                    Console.WriteLine($"Jugador: {jugador} | Equipo: {equipo.Nombre}");
                    hayJugadores = true;
                }
            }

            if (!hayJugadores)
            {
                Console.WriteLine("No hay jugadores registrados.");
            }
        }

        public void MostrarJugadoresPorEquipo()
        {
            Console.WriteLine("\n===== JUGADORES POR EQUIPO =====");
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
                return;
            }

            foreach (var equipo in equipos.Values)
            {
                Console.WriteLine($"\nEquipo: {equipo.Nombre}");
                if (equipo.Jugadores.Count == 0)
                {
                    Console.WriteLine("   Este equipo no tiene jugadores inscritos.");
                }
                else
                {
                    foreach (var jugador in equipo.Jugadores)
                    {
                        Console.WriteLine($"   - {jugador}");
                    }
                }
            }
        }
    }
}