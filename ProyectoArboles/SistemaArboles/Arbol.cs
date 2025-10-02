using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace SistemaArboles
{
    // Clase principal que representa un árbol
    public class Arbol
    {
        // Propiedades del árbol
        public string Nombre { get; set; }
        public NodoArbol Raiz { get; set; }
        private Dictionary<string, NodoArbol> nodos; // Diccionario para acceso rápido por ID

        // Constructor
        public Arbol(string nombre)
        {
            Nombre = nombre;
            nodos = new Dictionary<string, NodoArbol>();
        }

        // Establece el nodo raíz del árbol
        public void EstablecerRaiz(string id, string nombre)
        {
            if (Raiz != null)
                throw new InvalidOperationException("El árbol ya tiene una raíz");

            var nodo = new NodoArbol(id, nombre);
            Raiz = nodo;
            nodos[id] = nodo;
        }

        // Agrega un nuevo nodo como hijo de un nodo existente
        public void AgregarNodo(string id, string nombre, string idPadre)
        {
            if (!nodos.ContainsKey(idPadre))
                throw new ArgumentException($"El nodo padre con ID '{idPadre}' no existe");

            var padre = nodos[idPadre];
            var hijo = new NodoArbol(id, nombre);
            padre.AgregarHijo(hijo);
            nodos[id] = hijo;
        }

        // Obtiene un nodo por su ID
        public NodoArbol ObtenerNodo(string id)
        {
            return nodos.ContainsKey(id) ? nodos[id] : null;
        }

        // RECORRIDO PREORDEN: Raíz -> Hijos (Complejidad: O(n))
        public List<NodoArbol> RecorridoPreOrden()
        {
            var resultado = new List<NodoArbol>();
            PreOrdenRecursivo(Raiz, resultado);
            return resultado;
        }

        private void PreOrdenRecursivo(NodoArbol nodo, List<NodoArbol> resultado)
        {
            if (nodo == null) return;
            resultado.Add(nodo); // Procesa el nodo actual
            foreach (var hijo in nodo.Hijos)
            {
                PreOrdenRecursivo(hijo, resultado); // Procesa los hijos
            }
        }

        // RECORRIDO POSTORDEN: Hijos -> Raíz (Complejidad: O(n))
        public List<NodoArbol> RecorridoPostOrden()
        {
            var resultado = new List<NodoArbol>();
            PostOrdenRecursivo(Raiz, resultado);
            return resultado;
        }

        private void PostOrdenRecursivo(NodoArbol nodo, List<NodoArbol> resultado)
        {
            if (nodo == null) return;
            foreach (var hijo in nodo.Hijos)
            {
                PostOrdenRecursivo(hijo, resultado); // Procesa los hijos primero
            }
            resultado.Add(nodo); // Luego procesa el nodo actual
        }

        // RECORRIDO POR NIVELES usando BFS (Complejidad: O(n))
        public List<NodoArbol> RecorridoPorNiveles()
        {
            var resultado = new List<NodoArbol>();
            if (Raiz == null) return resultado;

            var cola = new Queue<NodoArbol>();
            cola.Enqueue(Raiz);

            while (cola.Count > 0)
            {
                var nodo = cola.Dequeue();
                resultado.Add(nodo);

                // Agrega todos los hijos a la cola
                foreach (var hijo in nodo.Hijos)
                {
                    cola.Enqueue(hijo);
                }
            }

            return resultado;
        }

        // Calcula la altura del árbol (Complejidad: O(n))
        public int CalcularAltura()
        {
            return CalcularAlturaRecursiva(Raiz);
        }

        private int CalcularAlturaRecursiva(NodoArbol nodo)
        {
            if (nodo == null || nodo.EsHoja())
                return 0;

            int maxAltura = 0;
            foreach (var hijo in nodo.Hijos)
            {
                int altura = CalcularAlturaRecursiva(hijo);
                if (altura > maxAltura)
                    maxAltura = altura;
            }

            return maxAltura + 1;
        }

        // Cuenta el total de nodos (Complejidad: O(1))
        public int ContarNodos()
        {
            return nodos.Count;
        }

        // Cuenta las hojas del árbol (Complejidad: O(n))
        public int ContarHojas()
        {
            return nodos.Values.Count(n => n.EsHoja());
        }

        // Busca nodos por nombre (Complejidad: O(n))
        public List<NodoArbol> BuscarPorNombre(string nombre)
        {
            return nodos.Values
                .Where(n => n.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Obtiene el camino desde la raíz hasta un nodo (Complejidad: O(h))
        public List<NodoArbol> ObtenerCamino(string idNodo)
        {
            var camino = new List<NodoArbol>();
            if (!nodos.ContainsKey(idNodo))
                return camino;

            var nodo = nodos[idNodo];
            while (nodo != null)
            {
                camino.Insert(0, nodo);
                nodo = nodo.Padre;
            }

            return camino;
        }

        // Visualiza el árbol en formato ASCII
        public void VisualizarArbol()
        {
            if (Raiz == null)
            {
                Console.WriteLine("  (Árbol vacío)");
                return;
            }
            VisualizarNodo(Raiz, "", true);
        }

        private void VisualizarNodo(NodoArbol nodo, string prefijo, bool esUltimo)
        {
            Console.WriteLine(prefijo + (esUltimo ? "└── " : "├── ") + nodo.Nombre);

            var nuevoPrefijo = prefijo + (esUltimo ? "    " : "│   ");

            for (int i = 0; i < nodo.Hijos.Count; i++)
            {
                bool esUltimoHijo = (i == nodo.Hijos.Count - 1);
                VisualizarNodo(nodo.Hijos[i], nuevoPrefijo, esUltimoHijo);
            }
        }

        // Genera un reporte completo del árbol
        public void GenerarReporte()
        {
            Console.WriteLine($"\n{'═',70}");
            Console.WriteLine($"  REPORTE DEL ÁRBOL: {Nombre}");
            Console.WriteLine($"{'═',70}");

            if (Raiz == null)
            {
                Console.WriteLine("  ⚠️  El árbol está vacío");
                return;
            }

            Console.WriteLine($"Raíz: {Raiz.Nombre}");
            Console.WriteLine($"Total de nodos: {ContarNodos()}");
            Console.WriteLine($"Altura del árbol: {CalcularAltura()}");
            Console.WriteLine($"Cantidad de hojas: {ContarHojas()}");

            Console.WriteLine($"\n{'─',70}");
            Console.WriteLine("VISUALIZACIÓN DEL ÁRBOL:");
            Console.WriteLine($"{'─',70}");
            VisualizarArbol();

            Console.WriteLine($"\n{'─',70}");
            Console.WriteLine("INFORMACIÓN DE NODOS:");
            Console.WriteLine($"{'─',70}");
            foreach (var nodo in nodos.Values.OrderBy(n => n.Nivel).ThenBy(n => n.Nombre))
            {
                string tipo = nodo.EsRaiz() ? "RAÍZ" : nodo.EsHoja() ? "HOJA" : "INTERNO";
                string padre = nodo.Padre != null ? nodo.Padre.Nombre : "-";
                Console.WriteLine($"  • {nodo.Nombre,-20} | Nivel: {nodo.Nivel} | Tipo: {tipo,-8} | Padre: {padre} | Hijos: {nodo.CantidadHijos()}");
            }

            Console.WriteLine($"\n{'─',70}");
            Console.WriteLine("RECORRIDO PREORDEN (Raíz → Hijos):");
            Console.WriteLine($"{'─',70}");
            var preorden = RecorridoPreOrden();
            Console.WriteLine("  " + string.Join(" → ", preorden.Select(n => n.Nombre)));

            Console.WriteLine($"\n{'─',70}");
            Console.WriteLine("RECORRIDO POSTORDEN (Hijos → Raíz):");
            Console.WriteLine($"{'─',70}");
            var postorden = RecorridoPostOrden();
            Console.WriteLine("  " + string.Join(" → ", postorden.Select(n => n.Nombre)));

            Console.WriteLine($"\n{'─',70}");
            Console.WriteLine("RECORRIDO POR NIVELES (BFS):");
            Console.WriteLine($"{'─',70}");
            var niveles = RecorridoPorNiveles();
            int nivelActual = -1;
            foreach (var nodo in niveles)
            {
                if (nodo.Nivel != nivelActual)
                {
                    nivelActual = nodo.Nivel;
                    Console.Write($"\n  Nivel {nivelActual}: ");
                }
                Console.Write($"{nodo.Nombre}  ");
            }
            Console.WriteLine();

            Console.WriteLine($"\n{'─',70}");
            Console.WriteLine("ANÁLISIS POR NIVELES:");
            Console.WriteLine($"{'─',70}");
            var porNivel = nodos.Values.GroupBy(n => n.Nivel).OrderBy(g => g.Key);
            foreach (var grupo in porNivel)
            {
                Console.WriteLine($"  Nivel {grupo.Key}: {grupo.Count()} nodos");
            }

            Console.WriteLine($"{'═',70}\n");
        }

        // Exporta el árbol a un archivo de texto
        public void ExportarTexto(string nombreArchivo)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Árbol: {Nombre}");
            sb.AppendLine($"Generado: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine();
            sb.AppendLine("Estructura:");
            ExportarNodo(Raiz, sb, "", true);

            File.WriteAllText(nombreArchivo, sb.ToString());
            Console.WriteLine($"✓ Archivo exportado: {nombreArchivo}");
        }

        private void ExportarNodo(NodoArbol nodo, StringBuilder sb, string prefijo, bool esUltimo)
        {
            sb.AppendLine(prefijo + (esUltimo ? "└── " : "├── ") + nodo.Nombre);

            var nuevoPrefijo = prefijo + (esUltimo ? "    " : "│   ");

            for (int i = 0; i < nodo.Hijos.Count; i++)
            {
                bool esUltimoHijo = (i == nodo.Hijos.Count - 1);
                ExportarNodo(nodo.Hijos[i], sb, nuevoPrefijo, esUltimoHijo);
            }
        }
    }
}