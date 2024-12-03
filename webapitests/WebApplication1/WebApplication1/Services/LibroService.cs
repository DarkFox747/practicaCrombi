using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services

{
    public class LibroService : ILibroService
    {
        private readonly IDbConnection _dbConnection;

        public LibroService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Libro>> GetAllLibrosAsync()
        {
            var query = "SELECT * FROM Libros";
            return await _dbConnection.QueryAsync<Libro>(query);
        }

        public async Task<Libro> GetLibroByIdAsync(int id)
        {
            var query = "SELECT * FROM Libros WHERE IDLibros = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Libro>(query, new { Id = id });
        }

        public async Task<bool> AddLibroAsync(Libro libro)
        {
            var query = @"
            INSERT INTO Libros (Titulo, Autor, Cantidad) 
            VALUES (@Titulo, @Autor, @Cantidad)";
            var result = await _dbConnection.ExecuteAsync(query, libro);
            return result > 0;
        }

        public async Task<bool> UpdateLibroAsync(Libro libro)
        {
            var query = @"
            UPDATE Libros 
            SET Titulo = @Titulo, Autor = @Autor, Cantidad = @Cantidad 
            WHERE IDLibros = @Id";
            var result = await _dbConnection.ExecuteAsync(query, libro);
            return result > 0;
        }
    }
}
