using System.Collections.Generic;

namespace Application.Dto
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Modulo { get; set; }
        public string Pagina { get; set; }
        public string Url { get; set; }
        public string Icono { get; set; }
        public int? IdPadre { get; set; }
        public int Orden { get; set; }
        public bool Vigencia { get; set; } 
        public bool Espermisopordefecto { get; set; }
        public List<Actions> Actions { get; set; }
        public List<MenuDto> Child { get; set; }
    }
    public class Actions
    {
        public int Id { get; set; }
        public int IdAccesos { get; set; }
        public int IdUsuario { get; set; }
        public int TipoPermiso { get; set; }
        public string NombreAccion { get; set; }
        public bool Activo { get; set; }
        public bool Vigencia { get; set; } 
    }
}
