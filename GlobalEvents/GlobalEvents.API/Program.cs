using GlobalEvents.API;

var builder = WebApplication.CreateBuilder(args);

var app = builder
            .ConfigureServices()
            .ConfigurePipeLine();

app.Run();
