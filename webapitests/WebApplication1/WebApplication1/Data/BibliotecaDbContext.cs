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
            Libros.Add(new Libro { Titulo = "El Señor de los Anillos", Autor = "J.R.R. Tolkien", ISBN = "978-0544003415" });
            Libros.Add(new Libro { Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", ISBN = "978-0307474728" });
            Libros.Add(new Libro { Titulo = "1984", Autor = "George Orwell", ISBN = "978-0451524935" });
            Libros.Add(new Libro { Titulo = "Don Quijote", Autor = "Miguel de Cervantes", ISBN = "978-0142437239" });
            Libros.Add(new Libro { Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", ISBN = "978-0156012195" });

            // Agregar usuarios de prueba
            Usuarios.Add(new Estudiante("E001", "Juan Pérez", "Ingeniería"));
            Usuarios.Add(new Estudiante("E002", "María García", "Medicina"));
            Usuarios.Add(new Profesor("P001", "Dr. Ramírez", "Ciencias"));
            Usuarios.Add(new Profesor("P002", "Dra. Martínez", "Humanidades"));
        }
    }
}
