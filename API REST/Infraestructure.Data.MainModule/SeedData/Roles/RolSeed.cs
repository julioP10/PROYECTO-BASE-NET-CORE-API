using Domain.MainModule.Entities;
using System.Collections.Generic;

namespace Infraestructure.Data.MainModule.SeedData.Roles
{
    public static class RolSeed
    {
        private static readonly List<Rol> _roles = new List<Rol>
        {
            Administrador.Seed()
        };

        public static IEnumerable<Rol> Seed()
        {
            return _roles;
        }
    }
}