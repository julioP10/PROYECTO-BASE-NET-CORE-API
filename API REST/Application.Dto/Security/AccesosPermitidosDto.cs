using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
  public class AccesosPermitidosDto
  {
    public int Id { get; set; }
    public int Idaccesos { get; set; }
    public int Tipopermiso { get; set; }
    public string Nombreaccion { get; set; }
    public int Idusuario { get; set; }
    public bool Activo { get; set; }
    public bool Vigencia { get; set; }
  }
}
