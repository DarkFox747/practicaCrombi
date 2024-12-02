using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IBibliotecaService
    {
        IEnumerable<Libro> ObtenerTodosLosLibros();
        Libro ObtenerLibroPorId(string Id);
        IEnumerable<Usuario> ObtenerTodosLosUsuarios();
        Usuario ObtenerUsuarioPorId(string id);
        bool PrestarLibro(string Id, string userId);
        bool DevolverLibro(string Id, string userId);
        void AgregarLibro(Libro libro);
        void RegistrarEstudiante(string id, string nombre);
        void RegistrarProfesor(string id, string nombre);
        void VerEstadoLibros();
        void VerLibrosPrestadosUsuario(string userId);
    }
}
