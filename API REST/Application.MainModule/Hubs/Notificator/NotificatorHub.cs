using Infraestructure.Crosscutting.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Application.MainModule.Hubs
{
    public class NotificatorHub : INotificatorHub
    {
        private readonly IHubContext<NotificationHub> _context;

        public NotificatorHub(IHubContext<NotificationHub> context)
        {
            _context = context;
        } 
        public Task UpdatePedidoUsuarioAsync(string grupo, object message)
        {
            return _context.Clients.Group(grupo).SendAsync("UpdatePedidoUsuario", message);
        }

        public Task UpdatePedidoAdministradorAsync(string grupo, object message)
        {
            return _context.Clients.Group(grupo).SendAsync("UpdatePedidoXAdministrador", message);
        }
        public Task UpdatePedidoEmpresaAsync(string grupo, object message)
        {
            return _context.Clients.Group(grupo).SendAsync("UpdatePedidoEmpresa", message);
        }
        public async Task UpdatePermissionAsync(int message)
        {
            await _context.Clients.All.SendAsync("eventUpdatePermision", message);
        }
 
    }
}