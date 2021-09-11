using Domain.Core.Settings;
using Infraestructure.Crosscutting.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Application.Core
{
    public static class Extension
    {  
        public static IServiceCollection RegisterExecutionSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ExecutionSetting>(configuration.GetSection(nameof(ExecutionSetting)));

            return services;
        }

        public static IServiceCollection AddMongoDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            return services;
        }
    }
}
