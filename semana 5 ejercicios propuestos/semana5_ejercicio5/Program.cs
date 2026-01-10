using System;                     // Importa funcionalidades básicas como Console
using System.Collections.Generic; // Permite usar listas genéricas como List<int>

/// Escribir un programa que almacene en una lista los números del 1 al 10
/// y los muestre por pantalla en orden inverso separados por comas.

namespace semana5_ejercicio1 // Define el espacio de nombres del programa
{
    public class Program // Clase principal del programa
    {
        public static void Main() // Método principal, punto de entrada del programa
        {
            // Se crea una lista vacía de enteros
            List<int> numeros = new List<int>();

            // Bucle for: agrega los números del 1 al 10 a la lista
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i); // Inserta cada número en la lista
            }

            // Invierte el orden de la lista (ahora será del 10 al 1)
            numeros.Reverse();

            Console.WriteLine("-----"); // Línea decorativa de apertura
            Console.WriteLine("Números del 10 al 1 separados por comas:");

            // Muestra los números separados por comas usando string.Join
            Console.WriteLine(string.Join(", ", numeros));

            Console.WriteLine("-----"); // Línea decorativa de cierre
        }
    }
}