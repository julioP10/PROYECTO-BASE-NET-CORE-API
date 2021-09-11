using Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MainModule.Entities
{
  public class Accesos : Entity<int>
  {
    public Accesos()
    {
      AccesosPermitidos = new HashSet<AccesosPermitidos>();
      AccesosRoles = new HashSet<AccesosRol>();
      ChildsNavigation = new HashSet<Accesos>();
    }
    public string Modulo { get; set; }
    public string Pagina { get; set; }
    public string Url { get; set; }
    public string Icono { get; set; }
    public int? IdPadre { get; set; }
    public int Orden { get; set; }
    public bool Vigencia { get; set; }
    public bool Espermisopordefecto { get; set; } 
    public ICollection<AccesosPermitidos> AccesosPermitidos { get; set; }
    public ICollection<AccesosRol> AccesosRoles { get; set; }
    public Accesos ParentNavigation { get; set; }
    public ICollection<Accesos> ChildsNavigation { get; set; }
  }
}
