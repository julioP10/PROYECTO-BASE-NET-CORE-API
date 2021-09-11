using Infraestructure.Crosscutting.Hubs;
using Microsoft.Extensions.DependencyInjection;

namespace Application.MainModule.Hubs
{
    public static class HubsExtension
    {
        public static void AddHubs(this IServiceCollection services)
        {
            services.AddScoped<INotificatorHub, NotificatorHub>();
            services.AddTransient<NotificationHub>();
        }
    }
}
