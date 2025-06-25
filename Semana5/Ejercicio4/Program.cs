class Program
{
    static void Main(string[] args)
    {
        // Crear el gestor de lotería
        GestorLoteria gestor = new GestorLoteria();
        
        // 1. Solicitar los números al usuario
        gestor.SolicitarNumeros();
        
        // 2. Ordenar los números
        gestor.OrdenarNumeros();
        
        // 3. Mostrar los números ordenados
        gestor.MostrarNumeros();
    }
}
