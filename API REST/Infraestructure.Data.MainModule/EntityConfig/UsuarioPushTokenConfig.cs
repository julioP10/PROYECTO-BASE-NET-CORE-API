using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.MainModule.EntityConfig
{
    public class UsuarioPushTokenConfig : IEntityTypeConfiguration<UsuarioPushToken>
    {
        public void Configure(EntityTypeBuilder<UsuarioPushToken> builder)
        {
        }
    }
}
