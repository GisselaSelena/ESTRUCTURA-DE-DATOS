using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string expression = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}"; // Ejemplo de entrada
        if (AreParenthesesBalanced(expression))
        {
            Console.WriteLine("Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Fórmula no balanceada.");
        }
    }

    /// <summary>
    /// Verifica si los paréntesis, llaves y corchetes en una expresión están balanceados.
    /// </summary>
    /// <param name="expression">La expresión matemática a verificar.</param>
    /// <returns>True si está balanceada, de lo contrario false.</returns>
    static bool AreParenthesesBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in expression)
        {
            // Si encontramos un carácter de apertura, lo apilamos
            if (ch == '{' || ch == '(' || ch == '[')
            {
                stack.Push(ch);
            }
            // Si encontramos un carácter de cierre, verificamos el tope de la pila
            else if (ch == '}' || ch == ')' || ch == ']')
            {
                if (stack.Count == 0) return false; // No hay un carácter de apertura correspondiente

                char top = stack.Pop();
                if (!IsMatchingPair(top, ch))
                {
                    return false; // Los caracteres no coinciden
                }
            }
        }

        // Si la pila está vacía, todos los paréntesis están balanceados
        return stack.Count == 0;
    }

    /// <summary>
    /// Verifica si un par de caracteres de apertura y cierre coinciden.
    /// </summary>
    /// <param name="opening">Carácter de apertura.</param>
    /// <param name="closing">Carácter de cierre.</param>
    /// <returns>True si coinciden, de lo contrario false.</returns>
    static bool IsMatchingPair(char opening, char closing)
    {
        return (opening == '{' && closing == '}') ||
               (opening == '(' && closing == ')') ||
               (opening == '[' && closing == ']');
    }
}
