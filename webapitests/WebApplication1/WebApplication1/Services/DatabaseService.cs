using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDbConnection _dbConnection;

        public DatabaseService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<IEnumerable<string>> GetNamesAsync()
        {
            try
            {
                // Consulta simple para obtener datos
                var query = "SELECT Name FROM SampleTable"; // Asegúrate de que la tabla existe
                var result = await _dbConnection.QueryAsync<string>(query);
                return result;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new ApplicationException($"Error al consultar la base de datos: {ex.Message}");
            }
        }
    }
}
