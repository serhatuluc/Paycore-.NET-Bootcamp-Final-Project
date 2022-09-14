using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnionArcExample.Application.Common.Interfaces.Services;
using OnionArcExample.Application.Interfaces.Services;
using OnionArcExample.Domain;
using OnionArcExample.WebAPI;
using OnionArcExample.WorkerService;
using UnluCo.FinalProject.WebApi.Application.Concrete;

namespace OnionArc.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    MailSettings mailSettings = configuration.GetSection("MailSettings").Get<MailSettings>();
                    services.AddSingleton(mailSettings);
                    services.AddScoped<IRabbitMQService, RabbitMQService>();
                    services.AddScoped<IEmailService, MailService>();
                    services.AddHostedService<Worker>();
                });
    }
}
