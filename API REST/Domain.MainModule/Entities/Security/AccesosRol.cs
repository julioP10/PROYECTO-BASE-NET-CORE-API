using Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MainModule.Entities 
{
  public class AccesosRol : Entity<int>
  {
    public int IdRol { get; set; }
    public int IdAccesos { get; set; }
    public Accesos Accesos { get; set; }
    public Rol Rol { get; set; }
  }
}
