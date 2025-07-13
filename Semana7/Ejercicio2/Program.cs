using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numberOfDisks = 3; // Cambia este valor para probar con diferentes cantidades de discos
        TowersOfHanoi hanoi = new TowersOfHanoi(numberOfDisks);
        hanoi.Solve();
    }
}

/// <summary>
/// Clase que representa el juego de las Torres de Hanoi.
/// </summary>
class TowersOfHanoi
{
    private Stack<int> towerA; // Torre de origen
    private Stack<int> towerB; // Torre auxiliar
    private Stack<int> towerC; // Torre de destino
    private int moveCount; // Contador de movimientos

    /// <summary>
    /// Constructor de la clase TowersOfHanoi.
    /// Inicializa las torres y apila los discos en la torre A.
    /// </summary>
    /// <param name="diskCount">Número de discos en el juego.</param>
    public TowersOfHanoi(int diskCount)
    {
        towerA = new Stack<int>();
        towerB = new Stack<int>();
        towerC = new Stack<int>();
        moveCount = 0;

        // Inicializar la torre A con discos (el disco más grande abajo)
        for (int i = diskCount; i >= 1; i--)
        {
            towerA.Push(i); // Insertar discos en la pila de origen
        }
    }

    /// <summary>
    /// Resuelve el problema de las Torres de Hanoi.
    /// </summary>
    public void Solve()
    {
        Console.WriteLine("Estado Inicial:");
        PrintTowers();
        MoveDisks(towerA.Count, towerA, towerC, towerB);
    }

    /// <summary>
    /// Mueve los discos entre las torres utilizando pilas.
    /// </summary>
    /// <param name="n">Número de discos.</param>
    /// <param name="source">Torre de origen.</param>
    /// <param name="target">Torre de destino.</param>
    /// <param name="auxiliary">Torre auxiliar.</param>
    private void MoveDisks(int n, Stack<int> source, Stack<int> target, Stack<int> auxiliary)
    {
        if (n > 0)
        {
            // Mover n-1 discos de origen a auxiliar
            MoveDisks(n - 1, source, auxiliary, target);
            
            // Mover el disco restante a destino
            int disk = source.Pop(); // Eliminar el disco de la parte superior
            target.Push(disk); // Insertar el disco en la torre de destino
            
            // Mostrar el movimiento y estado actual
            Console.WriteLine($"\nMovimiento #{++moveCount}:");
            Console.WriteLine($"Mover disco {disk} de {GetTowerName(source)} a {GetTowerName(target)}");
            PrintTowers();

            // Mover n-1 discos de auxiliar a destino
            MoveDisks(n - 1, auxiliary, target, source);
        }
    }

    /// <summary>
    /// Obtiene el nombre de la torre basado en la pila.
    /// </summary>
    /// <param name="tower">La pila que representa la torre.</param>
    /// <returns>Nombre de la torre.</returns>
    private string GetTowerName(Stack<int> tower)
    {
        if (tower == towerA) return "A";
        if (tower == towerB) return "B";
        return "C";
    }

    /// <summary>
    /// Imprime el estado actual de las torres.
    /// </summary>
    private void PrintTowers()
    {
        Console.WriteLine("Torre A: " + string.Join(", ", towerA.ToArray()));
        Console.WriteLine("Torre B: " + string.Join(", ", towerB.ToArray()));
        Console.WriteLine("Torre C: " + string.Join(", ", towerC.ToArray()));
    }
}
