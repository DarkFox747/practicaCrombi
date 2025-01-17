﻿using BibliotecaConSQL.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;


namespace BibliotecaConSQL.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbContextService _dbContext;

        public UsuarioService(DbContextService dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Usuario> GetUsuariosPorTipo(string tipoUsuario)
        {
            using (IDbConnection db = _dbContext.CreateConnection())
            {
                string query = @"
            SELECT 
                u.IDUsuarios, 
                u.Nombre, 
                u.TipoUsuario, 
                u.FechaInactivacion,
                COUNT(h.IDLibros) AS LibrosPrestados
            FROM Usuarios u
            LEFT JOIN HistorialBiblioteca h ON u.IDUsuarios = h.IDUsuarios
            WHERE u.TipoUsuario = @TipoUsuario
            GROUP BY u.IDUsuarios, u.Nombre, u.TipoUsuario, u.FechaInactivacion";

                return db.Query<Usuario>(query, new { TipoUsuario = tipoUsuario });
            }
        }





        public void AddUsuario(Usuario usuario, string tipo)
        {
            using (IDbConnection db = _dbContext.CreateConnection())
            {
                string query = "INSERT INTO Usuarios (Nombre, TipoUsuario) VALUES (@Nombre, @Tipo)";
                db.Execute(query, new { usuario.Nombre, Tipo = tipo });
            }
        }

        public void DeleteUsuario(string idUsuario)
        {
            using (IDbConnection db = _dbContext.CreateConnection())
            {
                string query = "UPDATE Usuarios SET FechaInactivacion = @Fecha WHERE IDUsuarios = @ID";
                db.Execute(query, new { Id = idUsuario, Fecha = DateTime.Now });
            }
        }
    }
}
