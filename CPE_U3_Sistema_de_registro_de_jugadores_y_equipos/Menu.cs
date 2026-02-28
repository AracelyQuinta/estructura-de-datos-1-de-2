using System;

namespace CPE_U3_Sistema_de_registro_de_jugadores_y_equipos
{
    public class Menu
    {
        private Torneo torneo = new Torneo();

        public void Mostrar()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n===== TORNEO DE FUTBOL =====");
                Console.WriteLine("1. Registrar nuevo equipo");
                Console.WriteLine("2. Registrar nuevo jugador en un equipo");
                Console.WriteLine("3. Mostrar todos los equipos");
                Console.WriteLine("4. Mostrar todos los jugadores");
                Console.WriteLine("5. Mostrar jugadores por equipo");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nombre del equipo: ");
                        string? nombreEquipo = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nombreEquipo))
                        {
                            Console.WriteLine("El nombre del equipo no puede estar vacío.");
                        }
                        else
                        {
                            torneo.RegistrarEquipo(nombreEquipo);
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el nombre del jugador: ");
                        string? nombreJugador = Console.ReadLine();

                        Console.Write("Ingrese el nombre del equipo: ");
                        string? nombreEquipoJugador = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nombreJugador) || string.IsNullOrWhiteSpace(nombreEquipoJugador))
                        {
                            Console.WriteLine("Datos inválidos. Intente nuevamente.");
                        }
                        else
                        {
                            torneo.RegistrarJugador(nombreJugador, nombreEquipoJugador);
                        }
                        break;

                    case 3:
                        torneo.MostrarEquipos();
                        break;

                    case 4:
                        torneo.MostrarJugadores();
                        break;

                    case 5:
                        torneo.MostrarJugadoresPorEquipo();
                        break;

                    case 6:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 6);
        }
    }
}
