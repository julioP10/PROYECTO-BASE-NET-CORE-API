using System.Collections.Generic;

namespace Application.Dto
{
    public class SidebarDto
    {
        public SidebarDto()
        {
            Menus = new List<MenuDto>();
        }

        public List<RolSideBarDto> Rol { get; set; } 
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public List<MenuDto> Menus { get; set; }
    }
}
