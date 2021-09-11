using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
 public class AccesosDto
  {
    public int Id { get; set; }
    public string Modulo { get; set; }
    public string Url { get; set; }
    public string Icono { get; set; }
    public int? Idpadre { get; set; }
    public int Orden { get; set; }
    public bool Vigencia { get; set; }
    public bool Espermisopordefecto { get; set; }
    public string Pagina { get; set; }
    public ICollection<AccesosDto> ChildsNavigation { get; set; }
    public ICollection<AccesosPermitidosDto> AccesosPermitidos { get; set; }
  }
}
