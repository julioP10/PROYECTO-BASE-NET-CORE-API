using System.Threading.Tasks;

namespace Infraestructure.Crosscutting.Hubs
{
    public interface INotificatorHub
    { 
        Task UpdatePermissionAsync(int message);
        Task UpdatePedidoUsuarioAsync(string grupo, object message);
        Task UpdatePedidoEmpresaAsync(string grupo, object message);
        Task UpdatePedidoAdministradorAsync(string grupo, object message);
    }
}