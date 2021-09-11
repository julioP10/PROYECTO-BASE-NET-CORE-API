using Application.Core;
using Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.MainModule.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<UsuarioDto> GetAsync(int id);
        Task<IEnumerable<OptionDto>> Search(string term);
        Task<IEnumerable<UsuarioDto>> SearchByMail(string term);
        Task<UsuarioDto> CreateAsync(UsuarioDto userDto);
        Task<UsuarioDto> UpdateAsync(UsuarioDto userDto);
        Task DeleteAsync(int id);
        Task UpdateStateAsync(int id, StateDto state); 
        Task<PaginationResultDto<UsuarioPaginationDto>> PaginateAsync(int pageIndex, int pageSize, string name,int? idRol, int? idEmpresa);
        Task<UsuarioPushTokenDto> SaveUsuarioPushTokenAsync(UsuarioPushTokenDto model);
        Task<ICollection<UsuarioPushTokenDto>> GetUsuarioPushTokenAsync(PushTokenDto request);
    }
}
