using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class UsuarioPushTokenDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int? IdEmpresa { get; set; }
        public int IdRol { get; set; }
        public string Device { get; set; }
        public string Domain { get; set; }
        public bool IsUpdate { get; set; }
        public string Key { get; set; } 
        public string Mensaje { get; set; }
        public string ActionUrl { get; set; }
    }

    public class PushTokenDto
    {
        public int IdUsuario { get; set; }
        public int? IdEmpresa { get; set; }
        public int IdRol { get; set; }
        public string Mensaje { get; set; }
        public string ActionUrl { get; set; }
    }

    public class TokenPush
    {
        public string endpoint { get; set; }
        public int? expirationTime { get; set; }
        public TokenKey keys { get; set; }
    }
    public class TokenKey
    {
        public string p256dh { get; set; }
        public string auth { get; set; }

    }
}
