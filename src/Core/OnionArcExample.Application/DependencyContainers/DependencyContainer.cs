using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FluentValidation.AspNetCore;
using FluentValidation;
using OnionArcExample.Application.Validator;

namespace OnionArcExample.Application.DependencyContainers
{
    public static class DependencyContainer
    {
        public static JwtConfig JwtConfig { get; private set; }
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            //FluentValidation validated
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(typeof(AuthorValidator));

            // services 
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();

            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());

             // Configure JWT Bearer
            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddJwtBearerAuthentication();

        }
    }
}
