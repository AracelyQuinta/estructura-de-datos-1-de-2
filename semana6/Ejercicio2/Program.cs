using System;                   // Importa funciones básicas como Console
using System.Collections.Generic; // Colecciones genéricas (aunque aquí no se usan)
using Ejercicio2;               // Importa el namespace donde está tu clase ListaEnlazada

/// Invertir una lista enlazada:
/// Implementar un método dentro de la lista enlazada que permita invertir los datos
/// almacenados en una lista enlazada, es decir que el primer elemento pase a ser el último
/// y el último pase a ser el primero, que el segundo sea el penúltimo y así sucesivamente.

class Program
{
    static void Main()
    {
        // Crear una nueva lista enlazada
        ListaEnlazada lista = new ListaEnlazada();

        // Insertar elementos al inicio de la lista
        lista.InsertarInicio(10);   // Lista: 10 -> null
        lista.InsertarInicio(20);   // Lista: 20 -> 10 -> null
        lista.InsertarInicio(30);   // Lista: 30 -> 20 -> 10 -> null

        // Mostrar la lista original
        Console.WriteLine("Lista original:");
        lista.Mostrar(); // Imprime: 30 -> 20 -> 10 -> null

        // Invertir la lista
        lista.Invertir();

        // Mostrar la lista invertida
        Console.WriteLine("Lista invertida:");
        lista.Mostrar(); // Imprime: 10 -> 20 -> 30 -> null
    }
}