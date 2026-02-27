using System;
using System.Collections.Generic;

namespace Semana11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se crea una instancia del diccionario con palabras precargadas
            Diccionario diccionario = new Diccionario();

            // Se crea el traductor, que usará el diccionario para traducir frases
            Traductor traductor = new Traductor(diccionario);

            int opcion; // variable para almacenar la opción del menú
            do
            {
                // Menú principal
                Console.WriteLine("==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                // Se lee la entrada del usuario y se valida que sea un número
                string entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Debe ingresar un número válido (0, 1 o 2).");
                    opcion = -1; // fuerza a repetir el menú si la entrada no es válida
                }

                // Se ejecuta la opción seleccionada
                switch (opcion)
                {
                    case 1:
                        // Traducción de frases completas
                        traductor.TraducirFrase();
                        break;

                    case 2:
                        // Agregar nuevas palabras al diccionario
                        Console.Write("Ingrese la palabra en español: ");
                        string espanol = Console.ReadLine();
                        Console.Write("Ingrese la traducción en inglés: ");
                        string ingles = Console.ReadLine();
                        diccionario.AgregarPalabra(espanol, ingles);
                        break;

                    case 0:
                        // Salir del programa
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        // Manejo de opciones inválidas
                        Console.WriteLine("Opción inválida, intente nuevamente.");
                        break;
                }

            } while (opcion != 0); // el menú se repite hasta que el usuario elija salir
        }
    }
}