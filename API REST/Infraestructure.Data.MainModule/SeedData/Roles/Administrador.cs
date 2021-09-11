using Domain.MainModule.Entities;
using Infraestructure.Crosscutting.Enums;
using System.Collections.Generic;

namespace Infraestructure.Data.MainModule.SeedData.Roles
{
    public static class Administrador
    {
        public static Rol Seed()
        {
            return new Rol
            {
                Nombre = "Administrador",
                Descripcion = "Perfil con el acceso total al sistema",
                Vigencia = (int)StateType.Active==1,
                UsuarioRoles = new List<UsuarioRol>
                {
                    new UsuarioRol
                    {
                        IdUsuario = 1
                    }
                }
            };
        }
    }
}
