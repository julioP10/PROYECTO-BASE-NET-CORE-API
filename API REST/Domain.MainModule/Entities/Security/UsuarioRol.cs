using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class UsuarioRol : Entity<int>
    {
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }

        public Rol Rol { get; set; }
        public Usuario Usuario { get; set; }
    }
}
