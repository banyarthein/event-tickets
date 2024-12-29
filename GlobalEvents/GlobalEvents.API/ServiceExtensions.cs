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

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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


    }
}
