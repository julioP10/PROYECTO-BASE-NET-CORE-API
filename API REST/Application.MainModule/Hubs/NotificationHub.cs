using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Application.MainModule.Hubs
{
    public class NotificationHub : Hub
    {
        public Task Register(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public Task UnRegister(string group)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        }
    }
}