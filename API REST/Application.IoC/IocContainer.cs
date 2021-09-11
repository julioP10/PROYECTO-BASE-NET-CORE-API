using Application.MainModule;
using Application.MainModule.Interfaces;
using Application.MainModule.Scheduler;
using Application.Security;
using Application.Security.Interfaces;
using Domain.Core.Interfaces.UoW;
using Domain.MainModule.Interfaces;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infraestructure.Crosscutting.Scheduler;
using Infraestructure.Data.Core.UoW;
using Infraestructure.Data.MainModule; 
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC
{
    public static class IocContainer
    {
        public static void AddDependencyInjectionInterfaces(this IServiceCollection services)
        {
            services.AddScoped<DbContext, MainModuleContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<IScheduler, HangfireScheduler>();


            services.AddDependencyInjectionAppService();
            services.AddDependencyInjectionRepository();
            services.AddDependencyInjectionService();
            services.AddDependencyInjectionHelpers();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void AddDependencyInjectionHelpers(this IServiceCollection services)
        {
            //services.AddScoped<IMessageBroker, AwsMessageBroker>();
        }

        private static void AddDependencyInjectionAppService(this IServiceCollection services)
        {

            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        }


        private static void AddDependencyInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        private static void AddDependencyInjectionService(this IServiceCollection services)
        {
            // 
        }
    }
}
