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
            string query = "INSERT INTO Libros (IDLibros, Titulo, Autor, Disponibilidad, cantidad) VALUES (@IDLibros, @Titulo, @Autor, @Disponibilidad, @cantidad)";
            _dbConnection.Execute(query, libro);
        }


        public void EliminarLibro(string idLibro)
        {
            try
            {
                string queryVerificar = "SELECT Cantidad FROM Libros WHERE IDLibros = @ID";
                int cantidad = _dbConnection.ExecuteScalar<int>(queryVerificar, new { ID = idLibro });

                if (cantidad == 0)
                {
                    throw new KeyNotFoundException("El libro con el ID especificado no existe o ya no hay copias disponibles.");
                }

                string query = @"
            UPDATE Libros 
            SET 
                Cantidad = Cantidad - 1, 
                Disponibilidad = CASE 
                    WHEN Cantidad - 1 > 0 THEN 'Disponible' 
                    ELSE 'No Disponible' 
                END, 
                FechaInactivacion = CASE 
                    WHEN Cantidad - 1 = 0 THEN @Fecha 
                    ELSE NULL 
                END 
            WHERE IDLibros = @ID";

                _dbConnection.Execute(query, new { ID = idLibro, Fecha = DateTime.Now });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes registrar el error o lanzar una excepción personalizada
                throw new Exception("Ocurrió un error al intentar eliminar el libro.", ex);
            }
        }



        public void DevolverLibro(string idLibro)
        {
            string query = "UPDATE Libros SET Cantidad = Cantidad + 1,Disponibilidad = CASE WHEN Cantidad - 1 > 0 THEN 'Disponible' ELSE 'No Disponible'END, FechaInactivacion = NULL WHERE IDLibros = @ID";
            _dbConnection.Execute(query, new { ID = idLibro});
        }
    }
}
