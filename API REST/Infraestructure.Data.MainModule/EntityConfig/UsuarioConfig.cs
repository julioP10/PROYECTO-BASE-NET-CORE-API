using Domain.MainModule.Entities;
using Infraestructure.Crosscutting.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.MainModule.EntityConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //builder.Property(e => e.NombreCompleto)
            //        .IsRequired()
            //        .HasMaxLength(250)
            //        .IsUnicode(false); 

            //builder.Property(e => e.Clave)
            //    .IsRequired()
            //    .HasMaxLength(100)
            //    .IsUnicode(false);

            //builder.Property(e => e.NombreUsuario)
            //    .IsRequired()
            //    .HasMaxLength(100)
            //    .IsUnicode(false);

            //SeedData(builder);
        }

        public void SeedData(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(
                new Usuario
                {
                    Id = 1,
                    NombreCompleto = "admin", 
                    NombreUsuario = "admin",
                    Clave = "Qm6u5yaNAZnx2wwYrGpyFw==",
                    ModoAutenticacion = (int)AuthenticationType.DataBase,
                    EsSuperUsuario = true,
                    Vigencia = (int)StateType.Active==1
                });
        }
    }
}
