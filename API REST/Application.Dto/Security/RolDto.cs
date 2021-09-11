using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
  public class RolDto
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public bool Vigencia { get; set; }
    public ICollection<AccesosRolDto> AccesosRoles { get; set; }
  }
    public class RolSideBarDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }
    }
}
