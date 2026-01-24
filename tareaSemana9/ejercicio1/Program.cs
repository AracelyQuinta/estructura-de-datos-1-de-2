/*
Verificación de paréntesis balanceados en una expresión matemática
Implemente un programa que determine si los paréntesis, llaves y corchetes
en una expresión matemática están correctamente balanceados.
Ejemplo:
Entrada: {7 + (8 * 5) - [(9 - 7) + (4 + 1)]}
Salida esperada: Fórmula balanceada.
  */
using System;                  // Importa funcionalidades básicas de C# (entrada/salida, etc.)
using System.Collections.Generic; // Permite usar colecciones genéricas como Stack<T>
using System.Text;             // Permite usar StringBuilder para construir cadenas eficientemente

class Program
{
    // Método que verifica si una expresión está balanceada
    static bool EstaBalanceado(string expresion)
    {
        Stack<char> pila = new Stack<char>(); // Pila para almacenar símbolos de apertura

        foreach (char c in expresion) // Recorremos cada carácter de la expresión
        {
            if (c == '(' || c == '{' || c == '[') // Si es un símbolo de apertura
            {
                pila.Push(c); // Lo guardamos en la pila
            }
            else if (c == ')' || c == '}' || c == ']') // Si es un símbolo de cierre
            {
                if (pila.Count == 0) return false; // Si no hay nada en la pila, está mal balanceado

                char tope = pila.Pop(); // Sacamos el último símbolo de apertura
                // Comprobamos si corresponde con el cierre actual
                if ((c == ')' && tope != '(') ||
                    (c == '}' && tope != '{') ||
                    (c == ']' && tope != '['))
                {
                    return false; // Si no coincide, la fórmula está desbalanceada
                }
            }
        }

        return pila.Count == 0; // Si al final la pila está vacía, está balanceado
    }

    // Método que balancea la fórmula agregando los símbolos faltantes
    static string BalancearFormula(string expresion)
    {
        Stack<char> pila = new Stack<char>(); // Pila para aperturas
        StringBuilder resultado = new StringBuilder(); // Construimos la nueva fórmula

        foreach (char c in expresion) // Recorremos cada carácter
        {
            if (c == '(' || c == '{' || c == '[') // Apertura
            {
                pila.Push(c);
                resultado.Append(c);
            }
            else if (c == ')' || c == '}' || c == ']') // Cierre
            {
                if (pila.Count > 0)
                {
                    char tope = pila.Peek(); // Revisamos el último símbolo abierto
                    if ((c == ')' && tope == '(') ||
                        (c == '}' && tope == '{') ||
                        (c == ']' && tope == '['))
                    {
                        pila.Pop(); // Coincide → lo sacamos
                        resultado.Append(c); // Añadimos el cierre correcto
                    }
                    else
                    {
                        // Si no coincide, agregamos la apertura correcta al inicio
                        resultado.Insert(0, AbrirCorrecto(c));
                        resultado.Append(c);
                    }
                }
                else
                {
                    // Si no hay apertura, insertamos la correcta al inicio
                    resultado.Insert(0, AbrirCorrecto(c));
                    resultado.Append(c);
                }
            }
            else
            {
                resultado.Append(c); // Si no es símbolo, lo copiamos tal cual
            }
        }

        // Al final, cerramos lo que quede abierto en la pila
        while (pila.Count > 0)
        {
            resultado.Append(CerrarCorrecto(pila.Pop()));
        }

        return resultado.ToString(); // Devolvemos la fórmula balanceada
    }

    // Método auxiliar: devuelve el cierre correcto para una apertura
    static char CerrarCorrecto(char apertura)
    {
        return apertura == '(' ? ')' :
               apertura == '{' ? '}' : ']';
    }

    // Método auxiliar: devuelve la apertura correcta para un cierre
    static char AbrirCorrecto(char cierre)
    {
        return cierre == ')' ? '(' :
               cierre == '}' ? '{' : '[';
    }

    static void Main()
    {
        // Ejemplos de expresiones
        string expresion1 = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        string expresion2 = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]"; // falta cierre
        string expresion3 = "7 + 8) * 5("; // desbalanceada

        // Probamos cada expresión
        ProbarExpresion(expresion1);
        ProbarExpresion(expresion2);
        ProbarExpresion(expresion3);
    }

    // Método que analiza y muestra resultados
    static void ProbarExpresion(string expresion)
    {
        Console.WriteLine("\nOriginal: " + expresion);

        if (EstaBalanceado(expresion)) // Si ya está balanceada
        {
            Console.WriteLine("La fórmula ya está balanceada.");
        }
        else // Si no está balanceada
        {
            string corregida = BalancearFormula(expresion); // La corregimos
            Console.WriteLine("La fórmula estaba desbalanceada.");
            Console.WriteLine("Balanceada: " + corregida);
        }
    }
}