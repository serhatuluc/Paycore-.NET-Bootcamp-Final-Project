using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OnionArcExample.Application;
using OnionArcExample.Persistence;

namespace OnionArcExample.WebAPI
{
    public static class ExtensionService
    {
        public static void AddServices(this IServiceCollection services)
        {
            // services 
            services.AddScoped<IStoreService,StoreService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<ITokenService,TokenService>();


            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());


        }
    }
}
