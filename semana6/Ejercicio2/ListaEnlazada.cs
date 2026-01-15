using System;                  // Importa funcionalidades básicas como Console
using System.Collections.Generic; // Importa colecciones genéricas (listas, diccionarios, etc.)
using System.Linq;             // Importa funciones de LINQ (consultas sobre colecciones)
using System.Threading.Tasks;  // Importa soporte para tareas asíncronas

namespace Ejercicio2            // Define un espacio de nombres llamado Ejercicio2
{
    // Clase que representa una lista enlazada simple
    public class ListaEnlazada
    {
        private Nodo cabeza;    // Referencia al primer nodo de la lista (la "cabeza")

        // Método para insertar un nuevo nodo al inicio de la lista
        public void InsertarInicio(int valor)
        {
            Nodo nuevo = new Nodo(valor);   // Crear un nuevo nodo con el valor dado
            nuevo.Siguiente = cabeza;       // El nuevo nodo apunta al que era la cabeza
            cabeza = nuevo;                 // Ahora el nuevo nodo se convierte en la cabeza
        }

        // Método para mostrar todos los elementos de la lista
        public void Mostrar()
        {
            Nodo actual = cabeza;           // Comenzamos desde la cabeza
            while (actual != null)          // Mientras no lleguemos al final
            {
                Console.Write(actual.Valor + " -> "); // Mostrar el valor del nodo
                actual = actual.Siguiente;            // Avanzar al siguiente nodo
            }
            Console.WriteLine("null");      // Indicar el final de la lista
        }

        // Método para invertir la lista enlazada
        public void Invertir()
        {
            Nodo anterior = null;           // Nodo previo (inicia vacío)
            Nodo actual = cabeza;           // Nodo actual (inicia en la cabeza)
            Nodo siguiente = null;          // Nodo siguiente (para guardar referencia)

            while (actual != null)          // Mientras haya nodos en la lista
            {
                siguiente = actual.Siguiente;   // Guardar el siguiente nodo
                actual.Siguiente = anterior;    // Invertir el enlace (apuntar hacia atrás)
                anterior = actual;              // Avanzar "anterior" al nodo actual
                actual = siguiente;             // Avanzar "actual" al siguiente nodo
            }

            cabeza = anterior;              // Al final, la cabeza será el último nodo
        }
    }
}