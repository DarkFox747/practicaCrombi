using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public List<Libro> LibrosPrestados { get; set; } = new List<Libro>();

        public Usuario(string id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }

        public void AgregarLibroPrestado(Libro libro)
        {
            LibrosPrestados.Add(libro);
        }

        public void RemoverLibroPrestado(Libro libro)
        {
            LibrosPrestados.Remove(libro);
        }
    }
}
