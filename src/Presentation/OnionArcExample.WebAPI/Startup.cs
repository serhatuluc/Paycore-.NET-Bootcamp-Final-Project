using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Persistence.Repository;

namespace OnionArcExample.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static JwtConfig JwtConfig { get; private set; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // hibernate
            var connStr = Configuration.GetConnectionString("PostgreSqlConnection");
            services.AddNHibernatePosgreSql(connStr);
          //  services.AddTransient(typeof(IHibernateRepository<>), typeof(IHibernateRepository<>));
            services.AddScoped<IAccountRepository,AccountRepository>();
            services.AddScoped<IAuthorRepository,AuthorRepository>();
            services.AddScoped<IStoreRepository,StoreRepository>();
            services.AddScoped<ITokenRepository,TokenRepository>();

            // Configure JWT Bearer
            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            // service
            services.AddResponseCaching();
            services.AddServices();
            services.AddJwtBearerAuthentication();
            services.AddCustomizeSwagger();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PycApi v1"));
            }

            // middleware
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
