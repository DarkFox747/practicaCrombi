using BibliotecaConSQL.Models;

namespace BibliotecaConSQL.Services
{
    public interface IUsuarioService
    {
        void AddUsuario(Usuario usuario, string tipo);
        void DeleteUsuario(string idUsuario);
        IEnumerable<Usuario> GetUsuariosPorTipo(string tipoUsuario);
    }
}