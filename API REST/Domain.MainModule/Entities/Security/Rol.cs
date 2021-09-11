using Domain.Core.Entities;
using System.Collections.Generic;

namespace Domain.MainModule.Entities
{
  public class Rol : Entity<int>
  {
    public Rol()
    {
      AccesosRoles = new HashSet<AccesosRol>();
      UsuarioRoles = new HashSet<UsuarioRol>();
    }

    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public bool Vigencia { get; set; }

    public ICollection<AccesosRol> AccesosRoles { get; set; }
    public ICollection<UsuarioRol> UsuarioRoles { get; set; }
  }
}
