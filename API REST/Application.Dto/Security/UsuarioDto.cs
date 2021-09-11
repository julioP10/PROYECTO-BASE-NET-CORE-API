using System.Collections.Generic;

namespace Application.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
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
        public List<UsuarioRolDto> UsuarioRoles { get; set; }
        public bool EsCliente { get; set; } = false;
        public string UserKeyCulqui { get; set; } = "";
        public string NumeroIdentidad { get; set; }
        public string FechaNacimiento { get; set; }
        public string Genero { get; set; }
    }
}
