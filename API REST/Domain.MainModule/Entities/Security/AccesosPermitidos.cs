using Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MainModule.Entities
{
  public class AccesosPermitidos : Entity<int>
  { 
    public int IdAccesos { get; set; }
    public int TipoPermiso { get; set; }
    public string NombreAccion { get; set; }
    public int IdUsuario { get; set; }
    public bool Activo { get; set; }
    public bool Vigencia { get; set; }
    public Accesos Accesos { get; set; }
    public Usuario Usuario { get; set; }
  }

    public class AccesosSideBar  
    {
        public string RolSideBarDto { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Menus { get; set; } 
    }
}
