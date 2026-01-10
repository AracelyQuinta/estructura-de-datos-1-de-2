using System;                     // Importa funcionalidades básicas como Console
using System.Collections.Generic; // Permite usar listas genéricas como List<int>

/// Escribir un programa que pregunte al usuario los números ganadores de la lotería primitiva,
/// los almacene en una lista y los muestre por pantalla ordenados de menor a mayor.

namespace semana5_ejercicio1 // Define el espacio de nombres del programa
{
    public class Program // Clase principal del programa
    {
        public static void Main() // Método principal, punto de entrada del programa
        {
            Console.WriteLine("-----"); // Línea decorativa de apertura
            Console.WriteLine("Ingrese los números ganadores de la lotería primitiva:"); // Mensaje inicial

            // Se crea una lista para almacenar los números ganadores ingresados por el usuario
            List<int> numerosGanadores = new List<int>();

            // Bucle for para pedir 6 números al usuario
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"Ingrese el número {i + 1}: "); // Solicita el número correspondiente
                int numero;

                // Validación: el número debe ser entero entre 1 y 49, y no repetido
                while (!int.TryParse(Console.ReadLine(), out numero) || numero < 1 || numero > 49 || numerosGanadores.Contains(numero))
                {
                    Console.Write("Entrada inválida. Por favor, ingrese un número válido entre 1 y 49 que no haya sido ingresado previamente: ");
                }

                // Si el número es válido, se agrega a la lista
                numerosGanadores.Add(numero);
            }

            Console.WriteLine("-----"); // Línea decorativa de separación

            // Ordena la lista de números ganadores de menor a mayor
            numerosGanadores.Sort();

            // Muestra los números ganadores ordenados
            Console.WriteLine("Los números ganadores ordenados de menor a mayor son:");
            foreach (var numero in numerosGanadores)
            {
                Console.WriteLine(numero); // Imprime cada número
            }

            Console.WriteLine("-----"); // Línea decorativa de cierre
        }
    }
}