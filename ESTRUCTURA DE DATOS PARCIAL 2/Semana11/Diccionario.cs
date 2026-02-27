using System;
using System.Collections.Generic;

namespace Semana11
{
    // Clase Diccionario: almacena palabras en español y su traducción al inglés
    public class Diccionario
    {
        // Estructura de datos tipo diccionario (clave: palabra en español, valor: traducción en inglés)
        private Dictionary<string, string> palabras;

        // Constructor: inicializa el diccionario con algunas palabras precargadas
        public Diccionario()
        {
            palabras = new Dictionary<string, string>()
            {
                {"amor", "love"},
                {"esperanza", "hope"},
                {"vida", "life"},
                {"luz", "light"},
                {"corazon", "heart"},   // sin tilde para que coincida con la entrada del usuario
                {"dan", "give"},
                {"y", "and"},
                {"al", "to the"},
                {"tiempo", "time"},
                {"persona", "person"},
                {"año", "year"},
                {"camino", "way"},
                {"cosa", "thing"},
                {"hombre", "man"},
                {"mundo", "world"},
                {"trabajo", "work"},
                {"semana", "week"},
                {"caso", "case"},
                {"punto", "point"},
                {"gobierno", "government"},
                {"empresa", "company"}
            };
        }

        // Método para traducir una palabra del español al inglés
        public string TraducirPalabra(string palabra)
        {
            // Convertimos la palabra a minúsculas y eliminamos signos de puntuación comunes
            string limpia = palabra.ToLower().Trim(',', '.', ';', ':', '!', '?');

            // Si la palabra existe en el diccionario, devolvemos su traducción
            // Si no existe, devolvemos la palabra original sin cambios
            return palabras.ContainsKey(limpia) ? palabras[limpia] : palabra;
        }

        // Método para agregar nuevas palabras al diccionario
        public void AgregarPalabra(string espanol, string ingles)
        {
            // Normalizamos las entradas a minúsculas
            espanol = espanol.ToLower();
            ingles = ingles.ToLower();

            // Verificamos si la palabra en español ya existe en el diccionario
            if (!palabras.ContainsKey(espanol))
            {
                // Si no existe, la añadimos con su traducción
                palabras.Add(espanol, ingles);
                Console.WriteLine(" Palabra agregada correctamente.");
            }
            else
            {
                // Si ya existe, mostramos un mensaje de advertencia
                Console.WriteLine(" La palabra ya existe en el diccionario.");
            }
        }
    }
}
