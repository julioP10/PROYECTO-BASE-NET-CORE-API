using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.MainModule.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddCustomAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddExpressionMapping();
                config.AddCollectionMappers();
                config.AllowNullCollections = true;
                config.AddMaps(new[] { typeof(AutoMapperConfiguration) });
            }, AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}