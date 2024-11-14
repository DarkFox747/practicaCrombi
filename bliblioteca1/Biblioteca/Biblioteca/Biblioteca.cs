using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Biblioteca
    {
        public List<Libro> Libros { get; set; } = new List<Libro>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public void AgregarLibro(string titulo, string autor, string isbn)
        {
            Libros.Add(new Libro(titulo, autor, isbn));
        }

        public void RegistrarUsuario(string id, string nombre)
        {
            Usuarios.Add(new Usuario(id, nombre));
        }

        public bool PrestarLibro(string isbn, string userId)
        {
            Libro libro = Libros.FirstOrDefault(l => l.ISBN == isbn && l.Disponible);
            Usuario usuario = Usuarios.FirstOrDefault(u => u.ID == userId);

            if (libro != null && usuario != null)
            {
                libro.PrestarLibro();
                usuario.AgregarLibroPrestado(libro);
                return true;
            }
            return false;
        }

        public bool DevolverLibro(string isbn, string userId)
        {
            Usuario usuario = Usuarios.FirstOrDefault(u => u.ID == userId);
            if (usuario != null)
            {
                Libro libro = usuario.LibrosPrestados.FirstOrDefault(l => l.ISBN == isbn);
                if (libro != null)
                {
                    libro.DevolverLibro();
                    usuario.RemoverLibroPrestado(libro);
                    return true;
                }
            }
            return false;
        }

        public void VerEstadoLibros()
        {
            foreach (var libro in Libros)
            {
                Console.WriteLine($"{libro.Titulo} - {libro.Autor} - ISBN: {libro.ISBN} - " +
                                  $"{(libro.Disponible ? "Disponible" : "Prestado")}");
            }
        }

        public void VerLibrosPrestadosUsuario(string userId)
        {
            Usuario usuario = Usuarios.FirstOrDefault(u => u.ID == userId);
            if (usuario != null)
            {
                Console.WriteLine($"Libros prestados de {usuario.Nombre}:");
                foreach (var libro in usuario.LibrosPrestados)
                {
                    Console.WriteLine($"{libro.Titulo} - {libro.Autor} - ISBN: {libro.ISBN}");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
    }

}
