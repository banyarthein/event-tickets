using GlobalEvents.Application.Interface.Infrastructure;
using GlobalEvents.Application.Model.Mail;
using GlobalEvents.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalEvents.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, PostMarkEmailService>();

            return services;
        }
    }
}
