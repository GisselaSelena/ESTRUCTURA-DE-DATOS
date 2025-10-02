using System;
using System.IO;

namespace SistemaArboles
{
    // Clase responsable de cargar árboles desde archivos de texto
    public class CargadorArboles
    {
        // Carga un árbol desde un archivo .txt
        // Formato esperado:
        // ARBOL,NombreArbol
        // NODO,ID,Nombre,RAIZ (para la raíz)
        // NODO,ID,Nombre,IDPadre (para los demás nodos)
        public static Arbol CargarDesdeArchivo(string rutaArchivo)
        {
            // Verifica que el archivo exista
            if (!File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException($"No se encontró el archivo: {rutaArchivo}");
            }

            Arbol arbol = null;
            var lineas = File.ReadAllLines(rutaArchivo);

            // Lee el archivo línea por línea
            foreach (var linea in lineas)
            {
                var lineaLimpia = linea.Trim();

                // Ignora líneas vacías y comentarios
                if (string.IsNullOrWhiteSpace(lineaLimpia) || lineaLimpia.StartsWith("#"))
                    continue;

                var partes = lineaLimpia.Split(',');

                // Crea el árbol
                if (partes[0] == "ARBOL")
                {
                    arbol = new Arbol(partes[1].Trim());
                }
                // Agrega nodos al árbol
                else if (partes[0] == "NODO" && arbol != null)
                {
                    string id = partes[1].Trim();
                    string nombre = partes[2].Trim();

                    // Si es la raíz
                    if (partes.Length > 3 && partes[3].Trim().ToUpper() == "RAIZ")
                    {
                        arbol.EstablecerRaiz(id, nombre);
                    }
                    // Si es un nodo hijo
                    else if (partes.Length > 3)
                    {
                        string idPadre = partes[3].Trim();
                        arbol.AgregarNodo(id, nombre, idPadre);
                    }
                }
            }

            return arbol;
        }
    }
}