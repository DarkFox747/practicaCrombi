using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkTest.seeds
{
    public class UsersSeed: IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.HasData(
                new Usuarios { Nombre = "Jorge", Email = "jorge@gmail.com", Edad =21, ObraSocialId = 1 }
                );
        }

       
    }
}
