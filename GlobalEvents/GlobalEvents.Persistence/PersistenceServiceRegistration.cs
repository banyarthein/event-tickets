using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalEvents.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GlobalEventDbContext>(options =>
                           options.UseSqlServer(configuration.GetConnectionString("GlobalEventsConnectionStrings")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IEventRepo, EventRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();

            return services;
        }
    }
}
