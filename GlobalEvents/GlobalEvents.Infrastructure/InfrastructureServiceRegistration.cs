using GlobalEvents.Application.Features.Events.Queries.GetEventExport;
using GlobalEvents.Application.Interface.Infrastructure;
using GlobalEvents.Application.Model.Mail;
using GlobalEvents.Infrastructure.Export;
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
            services.AddTransient<ICSVExporter<GetEventsExportModel>, CSVExporter<GetEventsExportModel>>();
            //services.AddTransient<IEventExporter, CSVExporter<GetEventsExportModel>>();

            //services.AddTransient<IEventExporter, CSVExporter<GetEventsExportModel>>();

            return services;
        }
    }
}
