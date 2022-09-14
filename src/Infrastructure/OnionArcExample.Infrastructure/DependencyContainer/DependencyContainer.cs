using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArcExample.Application.Common.Interfaces.Services;
using OnionArcExample.Infrastructure.Services.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Infrastructure.DependencyContainer
{
    public static class DependencyContainer
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
