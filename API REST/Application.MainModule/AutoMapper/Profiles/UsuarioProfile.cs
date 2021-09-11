using Application.Core;
using Application.Dto;
using Application.Security.Core;
using AutoMapper;
using Domain.MainModule.Entities;
using Infraestructure.Crosscutting;
using Infraestructure.Crosscutting.Enums;
using Infraestructure.Crosscutting.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UserApp, UsuarioDto>();
            CreateMap<UsuarioDto, UserApp>();

            CreateMap<Usuario, UsuarioDto>()
                .ForMember(p => p.Vigencia, x => x.MapFrom(d => d.Vigencia));

            CreateMap<UsuarioDto, Usuario>()
                .AfterMap((dto, domain) =>
                 {
                     var temp = new List<UsuarioRol>();
                     domain.UsuarioRol.ToList().ForEach(x =>
                     {
                         temp.Add(x);
                         //new UsuarioRol() { Id = x.Id, IdRol = x.IdRol }
                     });
                     domain.UsuarioRol.Clear();

                     foreach (var userRol in dto.UsuarioRoles)
                     {
                         var existe = temp.ToList().Find(x => x.IdRol == domain.Id && x.IdRol == userRol.IdRol);
                         domain.Vigencia = (int)StateType.Active == 1;
                         domain.UsuarioRol.Add(new UsuarioRol { Id = existe == null ? 0 : existe.Id, IdRol = userRol.IdRol, IdUsuario = domain.Id });

                     }
                 })
                .ForMember(p => p.EsSuperUsuario, x => x.MapFrom(d => d.EsSuperUsuario))
                .ForMember(p => p.Vigencia, x => x.MapFrom(d => d.Vigencia));

            CreateMap<Usuario, UsuarioPaginationDto>()
                //.AfterMap((dto, domain) =>
                //{ 
                //  foreach (var userRol in dto.UsuarioRol)
                //  { 
                //    domain.RolesAsignados.Add(new RolDto { Id = userRol.IdRol, Nombre = userRol.Rol.Nombre }); 
                //  }
                //})
                .ForMember(p => p.Id, x => x.MapFrom(d => d.Id))
                .ForMember(p => p.RolesAsignados, x => x.MapFrom(d => d.UsuarioRol.Select(x => new RolDto { Id = x.Rol.Id, Nombre = x.Rol.Nombre, Descripcion = x.Rol.Descripcion, Vigencia = x.Rol.Vigencia })))
                .ForMember(p => p.Roles, x => x.MapFrom(d => string.Join(",", d.UsuarioRol.Select(a => a.Rol.Nombre).ToArray())))
                ;

            CreateMap<Usuario, UserApp>();
            CreateMap<UserApp, Usuario>();
            CreateMap<Usuario, OptionDto>()
                .ForMember(p => p.Value, x => x.MapFrom(d => d.Id))
                .ForMember(p => p.Label, x => x.MapFrom(d => d.NombreUsuario));
        }
    }
}
