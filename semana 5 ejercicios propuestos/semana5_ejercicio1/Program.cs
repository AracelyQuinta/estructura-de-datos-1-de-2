using System;                     // Importa el espacio de nombres básico de C#, necesario para usar la clase Console
using System.Collections.Generic; // Importa colecciones genéricas, como List<T>

/// Ejercicio 1
/// Escribir un programa que almacene las asignaturas de un curso 
/// (por ejemplo Matemáticas, Física, Química, Historia y Lengua)
/// en una lista y la muestre por pantalla.

namespace semana5_ejercicio1 // Define un espacio de nombres para organizar el código
{
    public class Program // Clase principal del programa
    {
        public static void Main() // Método principal, punto de entrada del programa
        {                         // El "static" es obligatorio para que se ejecute sin crear un objeto de Program

            // Se crea una lista de cadenas (strings) con las asignaturas
            List<string> asignaturas = new List<string>() { "Matemáticas", "Física", "Química", "Historia", "Lengua" };

            // Se recorre la lista con un bucle foreach
            foreach (var asignatura in asignaturas)
            {
                // Se imprime cada asignatura en pantalla
                Console.WriteLine($"Asignatura: {asignatura}");
            }

            // Línea de separación al final
            Console.WriteLine("-----");
        }
    }
}