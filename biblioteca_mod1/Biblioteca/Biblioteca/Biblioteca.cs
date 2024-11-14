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

        public void RegistrarEstudiante(string id, string nombre, string carrera)
        {
            Usuarios.Add(new Estudiante(id, nombre, carrera));
        }

        public void RegistrarProfesor(string id, string nombre, string departamento)
        {
            Usuarios.Add(new Profesor(id, nombre, departamento));
        }

        public bool PrestarLibro(string isbn, string userId)
        {
            Libro libro = Libros.FirstOrDefault(l => l.ISBN == isbn && l.Disponible);
            Usuario usuario = Usuarios.FirstOrDefault(u => u.ID == userId);

            if (libro != null && usuario != null && usuario.PuedePedirPrestado())
            {
                try
                {
                    libro.PrestarLibro();
                    usuario.AgregarLibroPrestado(libro);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al prestar el libro: {ex.Message}");
                    return false;
                }
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
                Console.WriteLine($"Libros prestados de {usuario.Nombre} ({usuario.ObtenerTipoUsuario()}):");
                foreach (var libro in usuario.LibrosPrestados)
                {
                    Console.WriteLine($"{libro.Titulo} - {libro.Autor} - ISBN: {libro.ISBN}");
                }
                Console.WriteLine($"Total de libros prestados: {usuario.LibrosPrestados.Count}");
                if (usuario is Estudiante)
                {
                    Console.WriteLine($"Límite de libros: 3");
                }
                else if (usuario is Profesor)
                {
                    Console.WriteLine($"Límite de libros: 5");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }

        public void CargarDatosPrueba()
        {
            // Agregar libros de prueba
            AgregarLibro("El Señor de los Anillos", "J.R.R. Tolkien", "978-0544003415");
            AgregarLibro("Cien años de soledad", "Gabriel García Márquez", "978-0307474728");
            AgregarLibro("1984", "George Orwell", "978-0451524935");
            AgregarLibro("Don Quijote", "Miguel de Cervantes", "978-0142437239");
            AgregarLibro("El Principito", "Antoine de Saint-Exupéry", "978-0156012195");

            // Agregar estudiantes de prueba
            RegistrarEstudiante("E001", "Juan Pérez", "Ingeniería");
            RegistrarEstudiante("E002", "María García", "Medicina");
            RegistrarEstudiante("E003", "Carlos López", "Arquitectura");

            // Agregar profesores de prueba
            RegistrarProfesor("P001", "Dr. Ramírez", "Ciencias");
            RegistrarProfesor("P002", "Dra. Martínez", "Humanidades");
        }
    }
}
