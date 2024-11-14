using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public bool Disponible { get; set; } = true;

        public Libro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
        }

        public void PrestarLibro()
        {
            Disponible = false;
        }

        public void DevolverLibro()
        {
            Disponible = true;
        }
    }

}
