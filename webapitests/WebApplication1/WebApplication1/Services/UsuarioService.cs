using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IDbConnection _dbConnection;

        public UsuarioService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            var query = "SELECT * FROM Usuarios";
            return await _dbConnection.QueryAsync<Usuario>(query);
        }

        public async Task<bool> AddUsuarioAsync(Usuario usuario)
        {
            var query = @"
            INSERT INTO Usuarios (Nombre, Tipo) 
            VALUES (@Nombre, @Tipo)";
            var result = await _dbConnection.ExecuteAsync(query, usuario);
            return result > 0;
        }

        public async Task<bool> UpdateUsuarioAsync(Usuario usuario)
        {
            var query = @"
            UPDATE Usuarios 
            SET Nombre = @Nombre, Tipo = @Tipo 
            WHERE IDUsuarios = @Id";
            var result = await _dbConnection.ExecuteAsync(query, usuario);
            return result > 0;
        }
    }
}
