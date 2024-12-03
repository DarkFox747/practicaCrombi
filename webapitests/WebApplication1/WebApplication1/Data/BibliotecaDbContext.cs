using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class BibliotecaDbContext
    {
        public List<Libro> Libros { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public BibliotecaDbContext()
        {
            Libros = new List<Libro>();
            Usuarios = new List<Usuario>();
            CargarDatosPrueba();
        }

        private void CargarDatosPrueba()
        {
            // Agregar libros de prueba
            Libros.Add(new Libro { Titulo = "El Señor de los Anillos", Autor = "J.R.R. Tolkien", IDLibros = "1", cantidad=1 });
            Libros.Add(new Libro { Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", IDLibros = "2", cantidad = 1 });
            Libros.Add(new Libro { Titulo = "1984", Autor = "George Orwell", IDLibros = "3", cantidad = 1 });
            Libros.Add(new Libro { Titulo = "Don Quijote", Autor = "Miguel de Cervantes", IDLibros = "4", cantidad = 1 });
            Libros.Add(new Libro { Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", IDLibros = "5", cantidad = 1 });

            // Agregar usuarios de prueba
            Usuarios.Add(new Estudiante("E001", "Juan Pérez"));
            Usuarios.Add(new Estudiante("E002", "María García"));
            Usuarios.Add(new Profesor("P001", "Dr. Ramírez"));
            Usuarios.Add(new Profesor("P002", "Dra. Martínez"));
        }
    }
}
