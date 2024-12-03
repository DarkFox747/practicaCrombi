using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BibliotecaService : IBibliotecaService
    {
        private readonly BibliotecaDbContext _context;

        public BibliotecaService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Libro> ObtenerTodosLosLibros() => _context.Libros;

        public Libro ObtenerLibroPorId(string Id) =>
            _context.Libros.FirstOrDefault(l => l.IDLibros == Id);

        public IEnumerable<Usuario> ObtenerTodosLosUsuarios() => _context.Usuarios;

        public Usuario ObtenerUsuarioPorId(string id) =>
            _context.Usuarios.FirstOrDefault(u => u.IDUsuarios == id);

        public bool PrestarLibro(string Id, string userId)
        {
            var libro = _context.Libros.FirstOrDefault(l => l.IDLibros == Id && l.Disponible);
            var usuario = _context.Usuarios.FirstOrDefault(u => u.IDUsuarios == userId);

            if (libro != null && usuario != null && usuario.PuedePedirPrestado())
            {
                try
                {
                    libro.PrestarLibro();
                    usuario.AgregarLibroPrestado(libro);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public bool DevolverLibro(string Id, string userId)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.IDUsuarios == userId);
            if (usuario != null)
            {
                var libro = usuario.LibrosPrestados.FirstOrDefault(l => l.IDLibros == Id);
                if (libro != null)
                {
                    libro.DevolverLibro();
                    usuario.RemoverLibroPrestado(libro);
                    return true;
                }
            }
            return false;
        }

        public void AgregarLibro(Libro libro)
        {
            _context.Libros.Add(libro);
        }

        public void RegistrarEstudiante(string id, string nombre)
        {
            _context.Usuarios.Add(new Estudiante(id, nombre));
        }

        public void RegistrarProfesor(string id, string nombre )
        {
            _context.Usuarios.Add(new Profesor(id, nombre));
        }

        public void VerEstadoLibros()
        {
            foreach (var libro in _context.Libros)
            {
                Console.WriteLine($"{libro.Titulo} - {libro.Autor} - Id: {libro.IDLibros} - " +
                                $"{(libro.Disponible ? "Disponible" : "Prestado")}");
            }
        }

        public void VerLibrosPrestadosUsuario(string userId)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.IDUsuarios == userId);
            if (usuario != null)
            {
                Console.WriteLine($"Libros prestados de {usuario.Nombre} ({usuario.ObtenerTipoUsuario()}):");
                foreach (var libro in usuario.LibrosPrestados)
                {
                    Console.WriteLine($"{libro.Titulo} - {libro.Autor} - Id: {libro.IDLibros}");
                }
            }
        }
    }
}
