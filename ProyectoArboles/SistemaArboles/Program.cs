using System;
using System.Text;

namespace SistemaArboles
{
    // Programa principal del Sistema de Análisis de Árboles
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n🌳 SISTEMA DE ANÁLISIS DE ÁRBOLES 🌳\n");
            Console.WriteLine("Cargando datos desde archivos de texto...\n");

            var inicioProceso = DateTime.Now;

            try
            {
                // EJEMPLO 1: Árbol Genealógico - Desde archivo
                Console.WriteLine("📂 Cargando Ejemplo 1 desde: arbol_genealogico.txt");
                var arbolGenealogico = CargadorArboles.CargarDesdeArchivo("arbol_genealogico.txt");
                arbolGenealogico.GenerarReporte();
                arbolGenealogico.ExportarTexto("reporte_genealogico.txt");

                // EJEMPLO 2: Sistema de Archivos - Desde archivo
                Console.WriteLine("\n📂 Cargando Ejemplo 2 desde: sistema_archivos.txt");
                var sistemaArchivos = CargadorArboles.CargarDesdeArchivo("sistema_archivos.txt");
                sistemaArchivos.GenerarReporte();
                sistemaArchivos.ExportarTexto("reporte_archivos.txt");

                // Análisis de rendimiento
                var finProceso = DateTime.Now;
                var tiempoTotal = (finProceso - inicioProceso).TotalMilliseconds;

                MostrarAnalisisRendimiento(arbolGenealogico, sistemaArchivos, tiempoTotal);
                MostrarAnalisisEstructura();

                Console.WriteLine("\n✨ Proceso completado exitosamente!\n");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"\n❌ ERROR: {ex.Message}");
                Console.WriteLine("\n💡 Asegúrate de crear los archivos:");
                Console.WriteLine("   - arbol_genealogico.txt");
                Console.WriteLine("   - sistema_archivos.txt");
                Console.WriteLine("\nEn el mismo directorio que el ejecutable.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ ERROR inesperado: {ex.Message}");
                Console.WriteLine($"Detalles: {ex.StackTrace}\n");
            }
        }

        // Muestra el análisis de rendimiento del sistema
        static void MostrarAnalisisRendimiento(Arbol arbol1, Arbol arbol2, double tiempoTotal)
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    ANÁLISIS DE RENDIMIENTO                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine($"\n⏱  Tiempo total de ejecución: {tiempoTotal:F2} ms");
            Console.WriteLine($"📊 Total de nodos procesados: {arbol1.ContarNodos() + arbol2.ContarNodos()}");
            Console.WriteLine($"🌳 Altura del árbol genealógico: {arbol1.CalcularAltura()}");
            Console.WriteLine($"📁 Altura del sistema de archivos: {arbol2.CalcularAltura()}");
        }

        // Muestra el análisis de la estructura de datos utilizada
        static void MostrarAnalisisEstructura()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              ANÁLISIS DE ESTRUCTURA DE DATOS: ÁRBOL                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");

            Console.WriteLine("\n📋 Estructura de Árbol con Lista de Hijos:");
            Console.WriteLine("   VENTAJAS:");
            Console.WriteLine("   ✓ Estructura jerárquica natural e intuitiva");
            Console.WriteLine("   ✓ Acceso directo a padre: O(1)");
            Console.WriteLine("   ✓ Recorrer hijos de un nodo: O(k) donde k = cantidad de hijos");
            Console.WriteLine("   ✓ Inserción de hijo: O(1)");
            Console.WriteLine("   ✓ Espacio eficiente: O(n) donde n = cantidad de nodos");
            Console.WriteLine("   ✓ Ideal para jerarquías (organigramas, archivos, genealogía)");

            Console.WriteLine("\n   DESVENTAJAS:");
            Console.WriteLine("   ✗ No permite ciclos (es una estructura estricta)");
            Console.WriteLine("   ✗ Buscar un nodo por nombre: O(n) - debe recorrer todo");
            Console.WriteLine("   ✗ Sin acceso aleatorio a hermanos");
            Console.WriteLine("   ✗ Eliminación compleja si hay muchos descendientes");

            Console.WriteLine("\n🎯 Complejidad temporal de operaciones implementadas:");
            Console.WriteLine("   • EstablecerRaiz: O(1)");
            Console.WriteLine("   • AgregarNodo: O(1) - acceso directo al padre");
            Console.WriteLine("   • RecorridoPreOrden: O(n) - visita cada nodo una vez");
            Console.WriteLine("   • RecorridoPostOrden: O(n) - visita cada nodo una vez");
            Console.WriteLine("   • RecorridoPorNiveles (BFS): O(n) - visita cada nodo una vez");
            Console.WriteLine("   • CalcularAltura: O(n) - debe visitar todos los nodos");
            Console.WriteLine("   • ContarNodos: O(1) - mantiene diccionario");
            Console.WriteLine("   • ContarHojas: O(n) - debe revisar cada nodo");
            Console.WriteLine("   • BuscarPorNombre: O(n) - búsqueda lineal");
            Console.WriteLine("   • ObtenerCamino: O(h) donde h = altura del árbol");

            Console.WriteLine("\n📊 Complejidad espacial:");
            Console.WriteLine("   • Almacenamiento total: O(n)");
            Console.WriteLine("   • Cada nodo mantiene: ID, Nombre, Padre, Lista de Hijos");
            Console.WriteLine("   • Diccionario adicional para acceso rápido por ID: O(n)");

            Console.WriteLine("\n🔄 Comparación con otras estructuras:");
            Console.WriteLine("   ÁRBOL vs LISTA:");
            Console.WriteLine("   • Árbol permite jerarquías, lista es lineal");
            Console.WriteLine("   • Búsqueda en árbol balanceado: O(log n), lista: O(n)");
            Console.WriteLine("   • Árbol mejor para datos jerárquicos");

            Console.WriteLine("\n   ÁRBOL vs GRAFO:");
            Console.WriteLine("   • Árbol: sin ciclos, un padre por nodo");
            Console.WriteLine("   • Grafo: permite ciclos, múltiples conexiones");
            Console.WriteLine("   • Árbol más simple y eficiente para jerarquías");
            Console.WriteLine("   • Grafo más flexible pero más complejo");
        }
    }
}