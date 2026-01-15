using System;
using System.Collections.Generic;
using numeroDeElementos = semana6.numeroDeElementos;


/// 1. Función que calcule el número de elementos de una lista:
/// La idea de este algoritmo es bastante sencilla, lo que tendremos q hacer para ver la longitud de
/// una lista es simplemente recorrer la lista hasta el final e ir contando el número de saltos. El principal motivo por el que deberíamos implementar es que nos es que nos permite aprender y comprender permite aprender y comprender
/// el manejo de los nodos.

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

