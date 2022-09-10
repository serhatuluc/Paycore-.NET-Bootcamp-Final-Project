using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Persistence.Repository;

namespace OnionArcExample.Persistence
{
    public static class DependencyContainer
    {
        public static void AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
          

            // hibernate
            var connStr = configuration.GetConnectionString("PostgreSqlConnection");
            services.AddNHibernatePosgreSql(connStr);
        }
    }
}
