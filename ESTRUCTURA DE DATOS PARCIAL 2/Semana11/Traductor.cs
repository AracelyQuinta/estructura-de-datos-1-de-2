using System;
using System.Collections.Generic;
using Semana11;

namespace Semana11
{
    // Clase Traductor: se encarga de procesar frases completas
    // usando el diccionario español → inglés
    public class Traductor
    {
        // Referencia al diccionario que contiene las traducciones
        private Diccionario diccionario;

        // Constructor: recibe un objeto Diccionario y lo guarda
        public Traductor(Diccionario diccionario)
        {
            this.diccionario = diccionario;
        }

        // Método para traducir frases completas del español al inglés
        public void TraducirFrase()
        {
            // Pedimos al usuario que ingrese la frase en español
            Console.Write("Ingrese la frase: ");
            string frase = Console.ReadLine();

            // Dividimos la frase en palabras separadas por espacios
            string[] palabras = frase.Split(' ');

            // Recorremos cada palabra y la traducimos usando el diccionario
            for (int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = diccionario.TraducirPalabra(palabras[i]);
            }

            // Reconstruimos la frase traducida uniendo las palabras
            string traduccion = string.Join(" ", palabras);

            // Mostramos la traducción final al usuario
            Console.WriteLine("Traducción: " + traduccion);
        }
    }
}

