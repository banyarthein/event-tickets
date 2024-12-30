using GlobalEvents.API;
using GlobalEvents.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder
            .ConfigureServices()
            .ConfigurePipeLine();

app.MapEventEndPoints();

app.Run();
