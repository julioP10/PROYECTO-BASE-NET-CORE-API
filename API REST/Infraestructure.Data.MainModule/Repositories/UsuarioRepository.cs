using Domain.Core.Pagination;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infraestructure.Crosscutting.Enums;
using Infraestructure.Data.Core;
using Infraestructure.Data.Core.Pagination;
using Infraestructure.Data.Core.SQL;
using Infrastructure.CrossCutting.Enums;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructure.Data.MainModule
{
    public class UsuarioRepository : Repository<Usuario, int>, IUsuarioRepository
    {
        private readonly SqlServer _sqlServer;
        public UsuarioRepository(DbContext context)
            : base(context)
        {
            _sqlServer = new SqlServer(context.Database.GetDbConnection().ConnectionString);
        }

        public IQueryable<Usuario> Search(string term)
        {
            var sqlTerm = $"%{term}%";
            return Find(p => p.Vigencia == ((int)StateType.Active == 1) && (EF.Functions.Like(p.NombreUsuario, sqlTerm) ||
                           EF.Functions.Like(p.Email, sqlTerm)));
        }

        public IQueryable<Usuario> FindByUsername(string username)
        {
            return Find(p => (p.NombreUsuario == username || p.Email == username) && p.Vigencia == true && p.Estado == true);
        }

        public IQueryable<Usuario> FindByUsernameAndPassword(string username, string encryptedPassword)
        {
            return Find(p => (p.NombreUsuario == username || p.Email == username) && p.Clave == encryptedPassword);
        }

        //public Task<IPaginationResult<Usuario>> PaginateAsync(PaginationParameters<Usuario> parameters, bool @readonly = true)
        //{
        //    return base.PaginateAsync(
        //    new PaginationParameters<Usuario>
        //    {
        //        Includes = p => p.Include(d => d.UsuarioRol),
        //        OrderType = parameters.OrderType,
        //        WhereFilter = parameters.WhereFilter,
        //        AmountRows = parameters.AmountRows,
        //        ColumnOrder = parameters.ColumnOrder,
        //        Start = parameters.Start

        //    }
        //    , @readonly);
        //}

        public Task<IPaginationResult<Usuario>> PaginateAsync(int pageIndex, int pageSize, string name, int? idRol, int? idEmpresa)
        {
            Expression<Func<Usuario, int>> columnOrder = (Usuario p) => p.Id;
            Expression<Func<Usuario, bool>> whereFilter = p => p.Vigencia == ((int)StateType.Active == 1);

            if (!string.IsNullOrEmpty(name))
                whereFilter = whereFilter.And(p => p.NombreUsuario.Contains(name));
            if (idRol.HasValue && idRol.Value > 0)
                whereFilter = whereFilter.And(p => p.UsuarioRol.Any(x => x.IdRol == idRol.Value));
            if (idEmpresa.HasValue && idEmpresa.Value > 0)
                whereFilter = whereFilter.And(p => p.IdEmpresa == idEmpresa.Value);
            return base.PaginateAsync(
                new PaginationParameters<Usuario>
                {
                    Includes = p => p.Include(d => d.UsuarioRol).ThenInclude(x => x.Rol),
                    OrderType = OrderType.Descending,
                    WhereFilter = whereFilter,
                    ColumnOrder = columnOrder,
                    Start = pageIndex * pageSize,
                    AmountRows = pageSize
                });

        }
        public async Task<bool> InsertPermisosAsync(int idUsuario, string IdRol)
        {
            /////////////////////////////////////
            ///
            using (var connection = new SqlConnection(Context.Database.GetDbConnection().ConnectionString))
            {
                using (var command = new SqlCommand("SP_InsertPermisos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("idUsuario", idUsuario);
                    command.Parameters.AddWithValue("IdRol", IdRol);

                    await connection.OpenAsync();

                    var reader = await command.ExecuteScalarAsync();

                    //using (var reader = await command.ExecuteReaderAsync())
                    //{
                    //    if (await reader.ReadAsync())
                    //    {
                    //        details = new FileDetails();
                    //        details.ApplicationName = reader["ApplicationName"].ToString();
                    //        details.FileName = reader["FileName"].ToString();
                    //        details.FileId = (int)reader["Id"];
                    //        details.MimeType = reader["MimeType"].ToString();
                    //        details.StoragePath = reader["InternalStoragePath"].ToString();
                    //        details.Checksum = reader["Checksum"].ToString();
                    //        details.DateStoredUtc = (DateTime)reader["DateStoredUtc"];
                    //    }
                    //}
                }
            }
            return true;
        }

        Task<Usuario> IUsuarioRepository.GetAsync(int id, Func<IQueryable<Usuario>, IIncludableQueryable<Usuario, object>> include)
        {
            return GetAsync(id, include);
        }

        async Task<UsuarioPushToken> IUsuarioRepository.SaveUsuarioPushTokenAsync(UsuarioPushToken model)
        {
            List<Parameter> parameters = new List<Parameter>() {
                    new Parameter() { key = "Id",  value = model.Id },
                    new Parameter() { key = "IdUsuario",  value =model.IdUsuario },
                    new Parameter() { key = "Device",  value =model.Device },
                    new Parameter() { key = "Domain",  value =model.Domain },
                    new Parameter() { key = "IsUpdate",  value =model.IsUpdate },
                    new Parameter() { key = "Key",  value =model.Key },
                    new Parameter() { key = "IdRol",  value =model.IdRol },
                    new Parameter() { key = "IdEmpresa",  value =model.IdEmpresa },
             };

            var response = await _sqlServer.TransaccionAsync<UsuarioPushToken>("[SP_SaveUsuarioPushToken]", parameters).
                ExecuteAsync(3, 500);

            return response.FirstOrDefault();
        }

        async Task<ICollection<UsuarioPushToken>> IUsuarioRepository.GetUsuarioPushTokenAsync(UsuarioPushToken model)
        {
            List<Parameter> parameters = new List<Parameter>() {
                    new Parameter() { key = "IdUsuario",  value =model.IdUsuario },
                    new Parameter() { key = "IdRol",  value =model.IdRol },
                    new Parameter() { key = "IdEmpresa",  value =model.IdEmpresa },
             };

            var response = await _sqlServer.TransaccionAsync<UsuarioPushToken>("[SP_GetUsuarioPushToken]", parameters).
                ExecuteAsync(3, 500);

            return response;
        }
    }
}
