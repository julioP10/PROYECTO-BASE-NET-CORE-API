using Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MainModule.Entities
{
   public  class UsuarioPushToken : Entity<int>
    {
        public int IdUsuario { get; set; }
        public int? IdEmpresa { get; set; }
        public int IdRol { get; set; }
        public string Device { get; set; }
        public string Domain { get; set; }
        public bool IsUpdate { get; set; }
        public string Key { get; set; }
    }
}
