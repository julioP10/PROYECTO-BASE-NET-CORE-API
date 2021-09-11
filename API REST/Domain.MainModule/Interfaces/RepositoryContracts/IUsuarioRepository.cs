using Domain.Core.Pagination;
using Domain.MainModule.Entities;
using Infraestructure.Data.Core.Pagination;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.MainModule.Interfaces.RepositoryContracts
{
    public interface IUsuarioRepository
    {
        IQueryable<Usuario> Search(string term);
        IQueryable<Usuario> FindByUsername(string username);

        IQueryable<Usuario> FindByUsernameAndPassword(string username, string encryptedPassword);

        Task<Usuario> GetAsync(int id);
        Task<Usuario> GetAsync(int id, Func<IQueryable<Usuario>, IIncludableQueryable<Usuario, object>> include = null);
        Task<IPaginationResult<Usuario>> PaginateAsync(int pageIndex, int pageSize, string name, int? idRol, int? idEmpresa);
        void Create(Usuario user);
        void Update(Usuario entity);
        void Delete(Usuario user);
        Task<bool> InsertPermisosAsync(int idUsuario, string idRol);
        Task<UsuarioPushToken> SaveUsuarioPushTokenAsync(UsuarioPushToken model);
        Task<ICollection<UsuarioPushToken>> GetUsuarioPushTokenAsync(UsuarioPushToken model);
    }
}
