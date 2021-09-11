using Domain.MainModule.Entities;
using Infraestructure.Data.Core.Context;
using Infraestructure.Data.MainModule.EntityConfig;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.MainModule
{
    public class MainModuleContext : DbContextBase
    {
        public MainModuleContext(DbContextOptions<MainModuleContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options, httpContextAccessor)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Tablas

            builder.ApplyConfiguration(new UsuarioConfig());
            //seguridad 
            builder.ApplyConfiguration(new UsuarioPushTokenConfig());
            #endregion Tablas
        }

        #region Tablas
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        //seguridad
        public virtual DbSet<Accesos> Accesos { get; set; }
        public virtual DbSet<AccesosPermitidos> AccesosPermitidos { get; set; }
        public virtual DbSet<AccesosRol> AccesosRol { get; set; }
        public virtual DbSet<UsuarioPushToken> UsuarioPushToken { get; set; }
        #endregion Tablas
    }
}
