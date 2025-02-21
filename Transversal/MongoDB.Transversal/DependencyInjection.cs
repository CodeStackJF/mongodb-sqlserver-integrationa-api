using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Transversal.MapperConfig;

namespace MongoDB.Transversal
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTransversal(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly((typeof(MapperConf))));
            return services;
        }
    }
}