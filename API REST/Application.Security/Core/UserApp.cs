namespace Application.Security.Core
{
    public class UserApp
    {
        public int Id { get; set; }
        public string Email { get; set; } 
        public bool Estado { get; set; }
        public bool Vigencia { get; set; }
        public int ModoAutenticacion { get; set; }
        public bool EsSuperUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public int? IdEmpresa { get; set; }
    }
}
