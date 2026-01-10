using System;                     // Importa funcionalidades básicas como Console
using System.Collections.Generic; // Permite usar listas genéricas como List<T>

// Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua) en una lista,
// pregunte al usuario la nota que ha sacado en cada asignatura, y después las muestre por pantalla con el mensaje:
// "En <asignatura> has sacado <nota>", donde <asignatura> es cada una de las asignaturas de la lista y <nota> cada una de las correspondientes notas introducidas por el usuario.

namespace semana5_ejercicio1 // Define el espacio de nombres del programa
{
    public class Program // Clase principal
    {
        public static void Main() // Método principal del programa
        {
            Console.WriteLine("-----");
            Console.WriteLine("Asignaturas cursadas:");

            // Lista de asignaturas del curso
            List<string> asignaturas = new List<string>() { "Matemáticas", "Física", "Química", "Historia", "Lengua" };

            // Muestra las asignaturas por pantalla
            foreach (var asignatura in asignaturas)
            {
                Console.WriteLine($"- {asignatura}");
            }

            Console.WriteLine("-----");
            Console.WriteLine("A continuación se le pedirá que ingrese la nota obtenida en cada asignatura:");

            // Diccionario para almacenar asignatura y nota correspondiente
            Dictionary<string, double> notasPorAsignatura = new Dictionary<string, double>();

            // Solicita al usuario la nota de cada asignatura
            foreach (var asignatura in asignaturas)
            {
                double nota;
                Console.Write($"Ingrese la nota obtenida en {asignatura}: ");

                // Validación: solo acepta números entre 0 y 10
                while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
                {
                    Console.Write("Entrada inválida. Por favor, ingrese una nota válida entre 0 y 10: ");
                }

                // Guarda la nota en el diccionario
                notasPorAsignatura[asignatura] = nota;
            }

            Console.WriteLine("-----");
            Console.WriteLine("Resumen de calificaciones:");

            // Muestra el mensaje final con asignatura y nota
            foreach (var asignatura in asignaturas)
            {
                Console.WriteLine($"En {asignatura} has sacado {notasPorAsignatura[asignatura]}");
            }

            Console.WriteLine("-----");
        }
    }
}