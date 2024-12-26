using EntityFrameworkTest.Models;
using EntityFrameworkTest.seeds;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Context
{
    public class UsuariosContext: DbContext

    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<ObraSocial> ObraSocial { get; set; }
        //public DbSet<Medico> Medico { get; set; }
        //public DbSet<Consultorio> Consultorios { get; set; }
        // public DbSet<Turnos> Turnos { get; set; }
        // public DbSet<Medico_Obrasocial> medico_Obrasocial { get; set; }
        // public DbSet<Consultorios_Uso> consultorios_Uso { get; set; }

        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(p =>
            {
                p.ToTable("Usuarios");
                p.HasKey(p => p.IdUsuarios);
                p.Property(p => p.Email).IsRequired(); ;
                p.Property(p => p.Edad).IsRequired();               

                p.HasOne(u => u.ObraSocial)   
                 .WithMany()                 
                 .HasForeignKey(u => u.ObraSocialId)  
                 .OnDelete(DeleteBehavior.Cascade);


            });
            modelBuilder.Entity<ObraSocial>(p =>
            {
                p.ToTable("ObraSociales"); // Puedes definir el nombre de la tabla si lo deseas
                p.HasKey(o => o.IdObraSocial); // Configura la clave primaria
                p.Property(o => o.Nombre).IsRequired();
                p.Property(o => o.Descripcion);
            });

           // modelBuilder.ApplyConfiguration (new UsersSeed() );
        }

       



    }
}
