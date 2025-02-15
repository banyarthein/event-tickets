using GlobalEvents.API;
using GlobalEvents.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);
string routingRoot = "/api/";

var app = builder
            .ConfigureServices()
            .ConfigurePipeLine();

//await app.MigrateDataAsync();



app.CategoryEndPointsMapping(routingRoot, "categories");
app.EventEndPointsMapping(routingRoot, "events");

app.Run();
