/*
Resolución del problema de las Torres de Hanoi
Desarrolle un algoritmo que resuelva el problema de las Torres de Hanoi utilizando pilas.
El programa debe mostrar paso a paso cómo se mueven los discos entre las torres.

*/
using System;
using System.Collections.Generic;

class Program
{
    // Método para dibujar gráficamente las torres
    static void DibujarTorres(Stack<int> origen, Stack<int> auxiliar, Stack<int> destino, int numDiscos)
    {
        int[][] torres = {
            origen.ToArray(),
            auxiliar.ToArray(),
            destino.ToArray()
        };

        // Dibujamos desde arriba hacia abajo
        for (int nivel = numDiscos; nivel >= 1; nivel--)
        {
            for (int t = 0; t < 3; t++)
            {
                if (torres[t].Length >= nivel)
                {
                    int disco = torres[t][nivel - 1];
                    Console.Write(new string(' ', numDiscos - disco));
                    Console.Write(new string('=', disco * 2));
                    Console.Write(new string(' ', numDiscos - disco));
                }
                else
                {
                    Console.Write(new string(' ', numDiscos) + "|" + new string(' ', numDiscos));
                }
                Console.Write("   ");
            }
            Console.WriteLine();
        }

        // Base de las torres
        Console.WriteLine(new string('-', numDiscos * 2 + 2) + "   " +
                          new string('-', numDiscos * 2 + 2) + "   " +
                          new string('-', numDiscos * 2 + 2));
        Console.WriteLine("   Origen           Auxiliar           Destino");
        Console.WriteLine();
    }

    // Método para mostrar el estado textual de las torres
    static void MostrarTorres(Stack<int> origen, Stack<int> auxiliar, Stack<int> destino)
    {
        Console.WriteLine("Origen: " + string.Join(",", origen.ToArray()));
        Console.WriteLine("Auxiliar: " + string.Join(",", auxiliar.ToArray()));
        Console.WriteLine("Destino: " + string.Join(",", destino.ToArray()));
        Console.WriteLine("---------------------------");
    }

    // Algoritmo recursivo de Hanoi con visualización
    static void Hanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                      string nombreOrigen, string nombreDestino, string nombreAuxiliar, int numDiscos)
    {
        if (n > 0)
        {
            // Mover n-1 discos a la torre auxiliar
            Hanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino, numDiscos);

            // Mover el disco actual
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");

            // Mostrar gráfico y estado textual
            DibujarTorres(origen, auxiliar, destino, numDiscos);
            MostrarTorres(origen, auxiliar, destino);

            // Mover los n-1 discos de auxiliar a destino
            Hanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen, numDiscos);
        }
    }

    static void Main()
    {
        int numDiscos = 3; // Número de discos
        Stack<int> origen = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();
        Stack<int> destino = new Stack<int>();

        // Inicializamos la torre origen
        for (int i = numDiscos; i >= 1; i--)
        {
            origen.Push(i);
        }

        Console.WriteLine("Estado inicial:");
        DibujarTorres(origen, auxiliar, destino, numDiscos);
        MostrarTorres(origen, auxiliar, destino);

        // Resolver Hanoi con visualización
        Hanoi(numDiscos, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar", numDiscos);

        Console.WriteLine("Estado final:");
        DibujarTorres(origen, auxiliar, destino, numDiscos);
        MostrarTorres(origen, auxiliar, destino);
    }
}