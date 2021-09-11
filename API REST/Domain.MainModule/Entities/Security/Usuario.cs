using Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace Domain.MainModule.Entities
{
    public class Usuario : Entity<int>
    {
        public Usuario()
        {
            UsuarioRol = new HashSet<UsuarioRol>();
            AccesosPermitidos = new HashSet<AccesosPermitidos>();
        }

        public string Email { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }
        public bool Vigencia { get; set; }
        public int ModoAutenticacion { get; set; }
        public bool EsSuperUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public int? IdEmpresa { get; set; }
        public string SocialMedia { get; set; }
        public string UserSolcial { get; set; }
        public string NumeroCelular { get; set; }
        public string UserKeyCulqui { get; set; }
        public string NumeroIdentidad { get; set; }
        public string FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public DateTime fechaCreacion { get; set; }
        public ICollection<UsuarioRol> UsuarioRol { get; set; }
        public ICollection<AccesosPermitidos> AccesosPermitidos { get; set; } 

    }
}
