using System.Collections.Generic;

namespace Application.Dto
{
  public class UsuarioPaginationDto
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Clave { get; set; }
    public bool Estado { get; set; }
    public bool Vigencia { get; set; }
    public int ModoAutenticacion { get; set; }
    public bool EsSuperUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public string NombreCompleto { get; set; }
    public int? IdEmpresa { get; set; }
    public string Roles { get; set; }
    public List<RolDto> RolesAsignados { get; set; }
  }
}
