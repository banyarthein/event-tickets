using GlobalEvents.API;
using GlobalEvents.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);
string routingRoot = "/api/";

var app = builder
            .ConfigureServices()
            .ConfigurePipeLine();

await app.MigrateDataAsync();



app.EventEndPointsMapping(routingRoot, "Events");

app.Run();
