using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Context
{
    public class UsuariosContext: DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }
    }
}
