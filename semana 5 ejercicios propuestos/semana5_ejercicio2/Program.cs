using System;                     // Importa el espacio de nombres básico de C#, necesario para usar la clase Console
using System.Collections.Generic; // Importa colecciones genéricas, como List<T>

//// Escribir un programa que almacene las asignaturas de un curso 
/// (por ejemplo Matemáticas, Física, Química, Historia y Lengua) 
/// en una lista y la muestre por pantalla el mensaje "Yo estudio <asignatura>",
/// donde <asignatura> es cada una de las asignaturas de la lista.

namespace semana5_ejercicio1 // Define un espacio de nombres para organizar el código
{
    public class Program // Clase principal del programa
    {
        public static void Main() // Método principal, punto de entrada del programa
        {
            // Se crea una lista de cadenas (strings) con las asignaturas del curso
            List<string> asignaturas = new List<string>() { "Matemáticas", "Física", "Química", "Historia", "Lengua" };

            // Imprime una línea de separación al inicio
            Console.WriteLine("-----");

            // Bucle foreach: recorre cada elemento de la lista "asignaturas"
            foreach (var asignatura in asignaturas)
            {
                // Muestra en pantalla el mensaje "Yo estudio <asignatura>"
                Console.WriteLine($"Yo estudio {asignatura}");
            }

            // Imprime una línea de separación al final
            Console.WriteLine("-----");
        }
    }
}