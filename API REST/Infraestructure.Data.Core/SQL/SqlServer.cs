using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System;

namespace Infraestructure.Data.Core.SQL
{
    public class Parameter
    {
        public string key { get; set; }
        public object value { get; set; }
    }
    public class SqlServer
    {
        protected readonly string cn;

        public SqlServer(string cn) => this.cn = cn;

        public async Task<ICollection<T>> TransaccionAsync<T>(string procedure, Parameter parameter, int timeout = 0) where T : class, new()
        {
            return await TransaccionAsync<T>(procedure, new List<Parameter> { parameter }, timeout);
        }
        public async Task<T> TransaccionSingleAsync<T>(string procedure, Parameter parameter, int timeout = 0) where T : class, new()
        {
            return await TransaccionSingleAsync<T>(procedure, new List<Parameter> { parameter }, timeout);
        }

        public async Task<ICollection<T>> TransaccionAsync<T>(string procedure, ICollection<Parameter> parameters, int timeout = 0) where T : class, new()
        {
            //IEnumerable<T> list = new List<T>();
            List<T> RetVal = new List<T>();

            using (SqlConnection connection = new SqlConnection(cn))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedure;

                    if (timeout > 0) { command.CommandTimeout = timeout; }

                    if (parameters.Any())
                    {
                        foreach (Parameter parameter in parameters) { command.Parameters.AddWithValue(parameter.key, parameter.value); }
                    }

                    await connection.OpenAsync();

                    using (SqlDataReader dr = await command.ExecuteReaderAsync())
                    {
                        //if (reader.HasRows) list = AutoMapper.Mapper.Map<IDataReader, IEnumerable<T>>(reader);
                        //T RetVal = new T();
                        var Entity = typeof(T);
                        var PropDict = new Dictionary<string, PropertyInfo>();
                        try
                        {
                            if (dr != null && dr.HasRows)
                            {
                                RetVal = new List<T>();
                                var Props = Entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                                PropDict = Props.ToDictionary(p => p.Name.ToUpper(), p => p);
                                while (dr.Read())
                                {
                                    T newObject = new T();
                                    for (int Index = 0; Index < dr.FieldCount; Index++)
                                    {
                                        if (PropDict.ContainsKey(dr.GetName(Index).ToUpper()))
                                        {
                                            var Info = PropDict[dr.GetName(Index).ToUpper()];
                                            if ((Info != null) && Info.CanWrite)
                                            {
                                                var Val = dr.GetValue(Index);
                                                Info.SetValue(newObject, (Val == DBNull.Value) ? null : Val, null);
                                            }
                                        }
                                    }
                                    RetVal.Add(newObject);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        } 

                    }
                }
            }

            return RetVal.ToList();
        }

        public async Task<T> TransaccionSingleAsync<T>(string procedure, ICollection<Parameter> parameters, int timeout = 0) where T : class, new()
        {
            T RetVal = new T();

            using (SqlConnection connection = new SqlConnection(cn))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedure;

                    if (timeout > 0) { command.CommandTimeout = timeout; }

                    if (parameters.Any())
                    {
                        foreach (Parameter parameter in parameters) { command.Parameters.AddWithValue(parameter.key, parameter.value); }
                    }

                    await connection.OpenAsync();

                    using (SqlDataReader dr = await command.ExecuteReaderAsync())
                    {
                        var Entity = typeof(T);
                        var PropDict = new Dictionary<string, PropertyInfo>();
                        try
                        {
                            if (dr != null && dr.HasRows)
                            {
                                var Props = Entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                                PropDict = Props.ToDictionary(p => p.Name.ToUpper(), p => p);
                                dr.Read();
                                for (int Index = 0; Index < dr.FieldCount; Index++)
                                {
                                    if (PropDict.ContainsKey(dr.GetName(Index).ToUpper()))
                                    {
                                        var Info = PropDict[dr.GetName(Index).ToUpper()];
                                        if ((Info != null) && Info.CanWrite)
                                        {
                                            var Val = dr.GetValue(Index);
                                            Info.SetValue(RetVal, (Val == DBNull.Value) ? null : Val, null);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }

            return RetVal;
        }
    }
}
