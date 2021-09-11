using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Crosscutting 
{
    public static class ImageExtension
    {
        public static void AddImageConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ImageConfig>(configuration.GetSection(nameof(ImageConfig))); 
        }
    }
}
