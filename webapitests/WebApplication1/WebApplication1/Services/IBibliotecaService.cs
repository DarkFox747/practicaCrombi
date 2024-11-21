using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IBibliotecaService
    {
        IEnumerable<Libro> ObtenerTodosLosLibros();
        Libro ObtenerLibroPorISBN(string isbn);
        IEnumerable<Usuario> ObtenerTodosLosUsuarios();
        Usuario ObtenerUsuarioPorId(string id);
        bool PrestarLibro(string isbn, string userId);
        bool DevolverLibro(string isbn, string userId);
        void AgregarLibro(Libro libro);
        void RegistrarEstudiante(string id, string nombre, string carrera);
        void RegistrarProfesor(string id, string nombre, string departamento);
        void VerEstadoLibros();
        void VerLibrosPrestadosUsuario(string userId);
    }
}
