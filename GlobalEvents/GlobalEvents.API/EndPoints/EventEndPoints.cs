using GlobalEvents.Application.Exceptions;
using GlobalEvents.Application.Features.Events.Commands.CreateEvent;
using GlobalEvents.Application.Features.Events.Commands.UpdateEvent;
using GlobalEvents.Application.Features.Events.Queries.GetEventDetails;
using GlobalEvents.Application.Features.Events.Queries.GetEventList;
using MediatR;

namespace GlobalEvents.API.EndPoints
{
    public static class EventEndPoints
    {
        private static string moduleUrl = "";

        public static void EventEndPointsMapping(this WebApplication app, string routingRoot, string moduleName)
        {
            moduleUrl = routingRoot + moduleName;

            var moduleRoot = app.MapGroup(moduleUrl);

            moduleRoot.MapGet("/", GetAllEvents);

            moduleRoot.MapGet("/{id}", GetEventByID);

            moduleRoot.MapPost("/", CreateEvent);

            moduleRoot.MapPut("/{id}", UpdateEvent);
        }

        private async static Task<IResult> GetAllEvents(IMediator mediator)
        {
            var events = await mediator.Send(new GetEventsListQuery());
            return events.Any() ? Results.Ok(events) : Results.NoContent();
        }


        private async static Task<IResult> GetEventByID(IMediator mediator, Guid id)
        {
            var singleEvent = await mediator.Send(new GetEventDetailQuery { Id = id });
            return singleEvent != null ? Results.Ok(singleEvent) : Results.NotFound();
        }


        private async static Task<IResult> CreateEvent(IMediator mediator, CreateEventCommand eventCommand)
        {
            try
            {
                var singleEvent = await mediator.Send(eventCommand);

                if (singleEvent != null)
                    return Results.Created($"{moduleUrl}/{singleEvent.Id}", singleEvent);
                else
                    return Results.Problem();

            }
            catch (ValidationException ex)
            {
                return Results.Problem(ex.ValidationErrors.FirstOrDefault());
            }
        }


        private async static Task<IResult> UpdateEvent(IMediator mediator, Guid id, UpdateEventCommand eventCommand)
        {
            eventCommand.Id = id;
            var singleEvent = await mediator.Send(eventCommand);
            return singleEvent != null ? Results.Created() : Results.Problem();
        }

    }
}
