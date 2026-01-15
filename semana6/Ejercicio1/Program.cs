using System;
using System.Collections.Generic;
using numeroDeElementos = semana6.numeroDeElementos;


/// 
namespace semana6
{
    public class numeroDeElementos
    {
        static void Main(string[] args)
        {
            LinkedList<int> listaNumeros = new LinkedList<int>();

            foreach (int numeroAgregar in new int[] { 5,10, 15, 20,25, 30,35, 40, 50 })
            {
                listaNumeros.AddFirst(numeroAgregar);
            }

            // Mostrar elementos
            foreach (int n in listaNumeros)
            {
                Console.WriteLine(n + " ");
            }

            Console.WriteLine();

            // Mostrar longitud usando Count
            Console.WriteLine("Número de elementos: " + listaNumeros.Count);
        }

    }
}
