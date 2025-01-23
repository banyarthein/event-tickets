using GlobalEvents.Application;
using GlobalEvents.Infrastructure;
using GlobalEvents.Persistence;

namespace GlobalEvents.API
{
    public static class ServiceExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            //app.Services.AddEndpointsApiExplorer();
            //app.Services.AddSwaggerGen();


            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddTransient<IEventExporter, ICSVExporter<GetEventsExportModel>>();


            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);

            string[] corsURLs = [builder.Configuration["ApiURL"] ?? "http://localhost:3000",
                                builder.Configuration["CientURL"] ?? "http://localhost:4000"];

            //builder.Services.AddControllers();
            builder.Services.AddCors(options =>
                            options.AddPolicy(
                                                "CorsPolicy", policy => policy.WithOrigins(corsURLs)
                                                                            .AllowAnyMethod()
                                                                            .SetIsOriginAllowed(val => true)
                                                                            .AllowAnyHeader()
                                                                            .AllowCredentials()
                                            )
                                    );

            return builder.Build();

        }

        public static WebApplication ConfigurePipeLine(this WebApplication app)
        {
            app.UseCors("CorsPolicy");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            return app;
        }

        //public static Task MigrateDataAsync(this WebApplication app)
        //{
        //    using var scope = app.Services.CreateScope();
        //    {
        //        var services = scope.ServiceProvider;
        //        var logger = services.GetService<ILogger<Program>>();

        //        try
        //        {
        //            var context = services.GetRequiredService<GlobalEventDbContext>();
        //            if (context != null)
        //            {
        //                if (context.Database.EnsureCreated())
        //                {
        //                    //Seed Additional Data
        //                }
        //                else
        //                {
        //                    //await context.Database.MigrateAsync();
        //                    //await ApplicationDbContextSeed.SeedSampleDataAsync(context, logger);
        //                }

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            if (logger != null)
        //            {
        //                logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        //            }
        //        }
        //    }
        //}

    }
}
