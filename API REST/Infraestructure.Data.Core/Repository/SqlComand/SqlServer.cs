using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq; 

namespace Infraestructure.Data.Core.Repository.SqlComand
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

    public async Task<ICollection<T>> TransaccionAsync<T>(string procedure, Parameter parameter, int timeout = 0) where T : class
    {
      return await TransaccionAsync<T>(procedure, new List<Parameter> { parameter }, timeout);
    }

    public async Task<ICollection<T>> TransaccionAsync<T>(string procedure, ICollection<Parameter> parameters, int timeout = 0) where T : class
    {
      IEnumerable<T> list = new List<T>();

      using (SqlConnection connection = new SqlConnection(cn))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = procedure;

          if (timeout > 0) { command.CommandTimeout = timeout; }

          if (parameters.Any())
          {
            //foreach (Parameter parameter in parameters) { command.Parameters.AddWithValue(parameter.key, parameter.value.IsNull()); }
          }

          await connection.OpenAsync();

          using (SqlDataReader reader = await command.ExecuteReaderAsync())
          {
          
          }
        }
      }

      return list.ToList();
    }
  }
}
