using BibliotecaConSQL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaConSQL.Services
{
    public class BibliotecaService : IBibliotecaService
    {
        private readonly IDbConnection _dbConnection;

        public BibliotecaService(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<Libro> ObtenerLibros()
        {
            string query = "SELECT * FROM Libros WHERE FechaInactivacion IS NULL";
            return _dbConnection.Query<Libro>(query);
        }

        public void AgregarLibro(Libro libro)
        {
            string query = "INSERT INTO Libros (IDLibros, Titulo, Autor, Disponible, cantidad) VALUES (@IDLibros, @Titulo, @Autor, @Disponible, @cantidad)";
            _dbConnection.Execute(query, libro);
        }

        public void EliminarLibro(string idLibro)
        {
            string query = "UPDATE Libros SET Cantidad = Cantidad - 1, Disponible = CASE WHEN Cantidad - 1 > 0 THEN 1 ELSE 0 END, FechaInactivacion = CASE WHEN Cantidad - 1 = 0 THEN @Fecha ELSE NULL END WHERE IDLibros = @ID";
            _dbConnection.Execute(query, new { ID = idLibro, Fecha = DateTime.Now });
        }

        public void DevolverLibro(string idLibro)
        {
            string query = "UPDATE Libros SET Cantidad = Cantidad + 1, Disponible = 1, FechaInactivacion = NULL WHERE IDLibros = @ID";
            _dbConnection.Execute(query, new { ID = idLibro});
        }
    }
}
