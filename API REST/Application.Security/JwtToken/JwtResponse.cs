using Application.Dto;

namespace Application.Security.JwtToken
{
    public class JwtResponse
    {
        public string Id { get; set; } 
        public string AuthToken { get; set; }
        public double ExpireIn { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}