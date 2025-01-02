namespace GlobalEvents.API.EndPoints
{
    public static class EventEndPoints
    {
        internal record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
        {
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }



        public static void EventEndPointsMapping(this WebApplication app)
        {

            var summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();


            //    app.MapGet("/api/events", async (IEventService eventService) =>
            //    {
            //        var events = await eventService.GetEvents();
            //        return events.Any() ? Results.Ok(events) : Results.NoContent();
            //    });

            //    app.MapGet("/api/events/{id}", async (IEventService eventService, Guid id) =>
            //    {
            //    var event = await eventService.GetEventById(id);
            //    return event != null ? Results.Ok(event) : Results.NotFound();
            //});

            //app.MapPost("/api/events", async(IEventService eventService, CreateEventCommand command) =>
            //{
            //    var response = await eventService.CreateEvent(command);
            //    return response.Success? Results.Created($"/api/events/{response.Event.Id}", response) : Results.BadRequest(response);
            //});

            //app.MapPut("/api/events/{id}", async (IEventService eventService, Guid id, UpdateEventCommand command) =>
            //{
            //    if (id != command.Id)
            //    {
            //        return Results.BadRequest("Resource ID does not match the command ID");
            //    }

            //    var response = await eventService.UpdateEvent(command);
            //    return response.Success ? Results.Ok(response) : Results.BadRequest(response);
            //});

            //app.MapDelete("/api/events/{id}", async (IEventService eventService, Guid id) =>
            //{
            //    var response = await eventService.DeleteEvent(id);
            //    return response.Success ? Results.NoContent() : Results.BadRequest(response);
            //});

        }
    }
}
