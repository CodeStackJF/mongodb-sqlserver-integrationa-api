using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDb.Application.Data;
using MongoDB.Domain.Interfaces;
using MongoDB.Infrastructure.Repositories;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using MongoDB.Application.Data;
using MongoDB.Domain.Primitives;
using MongoDB.Infrastructure.Repositories.Mongo;
using MongoDB.Infrastructure.Repositories.SQLServer;

namespace MongoDB.Infrastructure
{
    public static class DependencyInjection
    {
         public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistance(configuration);
            return services;
        }

        private static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddScoped<IProductsRepository, MongoProductsRepository>();

            services.AddDbContext<SQLDbApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("UGBStoreCTX")));
            services.AddScoped<ISQLApplicationDbContext>(x=>x.GetRequiredService<SQLDbApplicationContext>());
            services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<SQLDbApplicationContext>());
            services.AddScoped<IProductsSQLRepository, SQLProductsRepository>();

           return services;
        }
    }
}