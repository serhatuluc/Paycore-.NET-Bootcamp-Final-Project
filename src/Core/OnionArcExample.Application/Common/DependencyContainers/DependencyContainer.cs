using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FluentValidation.AspNetCore;
using FluentValidation;
using OnionArcExample.Domain;
using MediatR;
using System.Reflection;
using OnionArcExample.Application.AuthorOperations;

namespace OnionArcExample.Application.DependencyContainers
{
    public static class DependencyContainer
    {
        public static JwtConfig JwtConfig { get; private set; }
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());


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
