using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

/// <summary>
/// Árbol binario de búsqueda con operaciones básicas.
/// </summary>
public class ArbolBinarioBusqueda
{
    // Raíz del árbol. null cuando el árbol está vacío.
    public Nodo Raiz;

    /// <summary>
    /// Inserta un valor en el árbol. No duplica valores ya existentes.
    /// </summary>
    /// <param name="valor">Valor a insertar.</param>
    public void Insertar(int valor)
    {
        Raiz = InsertarRecursivo(Raiz, valor);
    }

    /// <summary>
    /// Inserta recursivamente el valor en el subárbol.
    /// </summary>
    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null) return new Nodo(valor);
        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
        return nodo;
    }

    // Buscar
    /// <summary>
    /// Indica si el árbol contiene el valor dado.
    /// </summary>
    public bool Buscar(int valor)
    {
        return BuscarRecursivo(Raiz, valor);
    }

    /// <summary>
    /// Busca el valor recursivamente en el subárbol.
    /// </summary>
    private bool BuscarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null) return false;
        if (valor == nodo.Valor) return true;
        if (valor < nodo.Valor) return BuscarRecursivo(nodo.Izquierdo, valor);
        else return BuscarRecursivo(nodo.Derecho, valor);
    }

    // Eliminar
    /// <summary>
    /// Elimina el nodo que contiene el valor indicado (si existe) del árbol.
    /// </summary>
    public void Eliminar(int valor)
    {
        Raiz = EliminarRecursivo(Raiz, valor);
    }

    /// <summary>
    /// Elimina recursivamente y arregla referencias de subárboles.
    /// </summary>
    private Nodo EliminarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
        else
        {
            // Nodo con un hijo o ninguno
            if (nodo.Izquierdo == null)
                return nodo.Derecho;
            else if (nodo.Derecho == null)
                return nodo.Izquierdo;

            // Nodo con dos hijos: obtener el sucesor inorder (menor en subárbol derecho)
            nodo.Valor = MinimoRecursivo(nodo.Derecho);

            // Eliminar el sucesor inorder
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, nodo.Valor);
        }

        return nodo;
    }

    // Recorridos
    /// <summary>
    /// Retorna la lista de valores en recorrido inorden (izq - raíz - der).
    /// </summary>
    public List<int> InOrden()
    {
        List<int> resultado = new List<int>();
        InOrdenRecursivo(Raiz, resultado);
        return resultado;
    }

    /// <summary>
    /// Auxiliar recursivo para recorrido inorden.
    /// </summary>
    private void InOrdenRecursivo(Nodo nodo, List<int> resultado)
    {
        if (nodo != null)
        {
            InOrdenRecursivo(nodo.Izquierdo, resultado);
            resultado.Add(nodo.Valor);
            InOrdenRecursivo(nodo.Derecho, resultado);
        }
    }

    /// <summary>
    /// Retorna la lista de valores en recorrido preorden (raíz - izq - der).
    /// </summary>
    public List<int> PreOrden()
    {
        List<int> resultado = new List<int>();
        PreOrdenRecursivo(Raiz, resultado);
        return resultado;
    }

    /// <summary>
    /// Auxiliar recursivo para recorrido preorden.
    /// </summary>
    private void PreOrdenRecursivo(Nodo nodo, List<int> resultado)
    {
        if (nodo != null)
        {
            resultado.Add(nodo.Valor);
            PreOrdenRecursivo(nodo.Izquierdo, resultado);
            PreOrdenRecursivo(nodo.Derecho, resultado);
        }
    }

    /// <summary>
    /// Retorna la lista de valores en recorrido postorden (izq - der - raíz).
    /// </summary>
    public List<int> PostOrden()
    {
        List<int> resultado = new List<int>();
        PostOrdenRecursivo(Raiz, resultado);
        return resultado;
    }

    /// <summary>
    /// Auxiliar recursivo para recorrido postorden.
    /// </summary>
    private void PostOrdenRecursivo(Nodo nodo, List<int> resultado)
    {
        if (nodo != null)
        {
            PostOrdenRecursivo(nodo.Izquierdo, resultado);
            PostOrdenRecursivo(nodo.Derecho, resultado);
            resultado.Add(nodo.Valor);
        }
    }

    // Mínimo
    /// <summary>
    /// Retorna el valor mínimo del árbol (nodo más izquierdo).
    /// </summary>
    public int? Minimo()
    {
        if (Raiz == null) return null;
        return MinimoRecursivo(Raiz);
    }

    /// <summary>
    /// Busca el menor valor recursivamente en subárbol izquierdo.
    /// </summary>
    private int MinimoRecursivo(Nodo nodo)
    {
        if (nodo.Izquierdo == null) return nodo.Valor;
        return MinimoRecursivo(nodo.Izquierdo);
    }

    // Máximo
    /// <summary>
    /// Retorna el valor máximo del árbol (nodo más derecho).
    /// </summary>
    public int? Maximo()
    {
        if (Raiz == null) return null;
        return MaximoRecursivo(Raiz);
    }

    /// <summary>
    /// Busca el mayor valor recursivamente en subárbol derecho.
    /// </summary>
    private int MaximoRecursivo(Nodo nodo)
    {
        if (nodo.Derecho == null) return nodo.Valor;
        return MaximoRecursivo(nodo.Derecho);
    }

    // Altura
    /// <summary>
    /// Calcula la altura del árbol en número de niveles.
    /// </summary>
    public int Altura()
    {
        return AlturaRecursivo(Raiz);
    }

    /// <summary>
    /// Altura recursiva de un nodo (0 para nulo).
    /// </summary>
    private int AlturaRecursivo(Nodo nodo)
    {
        if (nodo == null) return 0;
        int izq = AlturaRecursivo(nodo.Izquierdo);
        int der = AlturaRecursivo(nodo.Derecho);
        return Math.Max(izq, der) + 1;
    }

    // Limpiar
    /// <summary>
    /// Elimina todos los nodos del árbol estableciendo raíz a null.
    /// </summary>
    public void Limpiar()
    {
        Raiz = null;
    }
}