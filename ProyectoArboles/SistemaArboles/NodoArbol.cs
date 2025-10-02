using System;
using System.Collections.Generic;

namespace SistemaArboles
{
    // Clase que representa un nodo del árbol
    public class NodoArbol
    {
        // Propiedades del nodo
        public string Id { get; set; }
        public string Nombre { get; set; }
        public NodoArbol Padre { get; set; }
        public List<NodoArbol> Hijos { get; set; }
        public int Nivel { get; set; }

        // Constructor: inicializa un nuevo nodo
        public NodoArbol(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Hijos = new List<NodoArbol>();
            Nivel = 0;
        }

        // Agrega un hijo a este nodo
        public void AgregarHijo(NodoArbol hijo)
        {
            hijo.Padre = this;
            hijo.Nivel = this.Nivel + 1;
            Hijos.Add(hijo);
        }

        // Verifica si el nodo es raíz (no tiene padre)
        public bool EsRaiz() => Padre == null;

        // Verifica si el nodo es hoja (no tiene hijos)
        public bool EsHoja() => Hijos.Count == 0;

        // Retorna la cantidad de hijos
        public int CantidadHijos() => Hijos.Count;

        // Representación en texto del nodo
        public override string ToString()
        {
            return $"[{Id}] {Nombre}";
        }
    }
} 