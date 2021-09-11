using API.ServiceConfigs;
using Application.Core;
using Application.IoC;
using Application.MainModule.AutoMapper;
using Application.MainModule.Hubs;
using Application.MainModule.Scheduler;
using Application.Security;
using Infraestructure.Crosscutting; 
using Infraestructure.Crosscutting.Email;
using Infraestructure.Crosscutting.Logging;
using Infraestructure.Crosscutting.Resources.Extensions;
using Infraestructure.Data.MainModule;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();

            services.AddDbContext<MainModuleContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Database.Generator"))
                    .EnableSensitiveDataLogging());

            services.AddMongoDbConnection(Configuration);
            services.RegisterExecutionSettings(Configuration); 
            services.AddCustomAutomapper();

            services.AddSignalR();
            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();
            services.AddEmailConfig(Configuration); 
            services.AddImageConfig(Configuration); 

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .SetIsOriginAllowed(_ => true)
                       .AllowCredentials();
            }));

            services.AddJsonLocalization(options => options.ResourcesPath = "Resources");
            services.AddDependencyInjectionInterfaces();
            services.AddHubs();

            services.AddJobs();

            services.AddSwaggerDocumentation();
            services.AddCustomAuthentication(Configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var signalRPath = Configuration.GetValue<string>("SignalRPath");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthorization();
            app.AddCustomErrorHandler();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>(signalRPath ?? "/notify");
            });
            app.UseAuthentication();

            // Swagger Configuration in API
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PROYECTO BASE API v1");

            }); 
        }
    }
}
