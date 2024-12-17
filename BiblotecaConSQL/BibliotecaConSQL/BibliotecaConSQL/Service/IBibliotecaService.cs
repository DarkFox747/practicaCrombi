using System.Collections.Generic;
using BibliotecaConSQL.Models;

namespace BibliotecaConSQL.Services
{
    public interface IBibliotecaService
    {
        IEnumerable<Libro> ObtenerLibros();
        void AgregarLibro(Libro libro);
        void EliminarLibro(string idLibro);
    }
}
