using System;                      // Importa funcionalidades básicas (como Console)
using System.Collections.Generic;  // Colecciones genéricas (listas, diccionarios, etc.)
using System.Linq;                 // Funciones de LINQ (consultas sobre colecciones)
using System.Threading.Tasks;      // Soporte para tareas asíncronas

namespace Ejercicio2                // Espacio de nombres: agrupa el código bajo "Ejercicio2"
{
    // Clase que representa un nodo de una lista enlazada
    public class Nodo
    {
        public int Valor;           // Dato que guarda el nodo (en este caso, un número entero)
        public Nodo Siguiente;      // Referencia al siguiente nodo en la lista

        // Constructor: se ejecuta cuando creamos un nuevo nodo
        public Nodo(int valor)
        {
            Valor = valor;          // Asigna el valor recibido al campo "Valor"
            Siguiente = null;       // Inicialmente no apunta a ningún nodo (es el final de la lista)
        }
    }
}