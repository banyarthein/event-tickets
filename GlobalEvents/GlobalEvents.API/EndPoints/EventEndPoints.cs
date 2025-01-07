using GlobalEvents.Application.Exceptions;
using GlobalEvents.Application.Features.Events.Commands.CreateEvent;
using GlobalEvents.Application.Features.Events.Commands.DeleteEvent;
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

            moduleRoot.MapGet("/", GetAll);

            moduleRoot.MapGet("/{id}", GetByID);

            moduleRoot.MapPost("/", Create);

            moduleRoot.MapPut("/{id}", Update);

            moduleRoot.MapDelete("/{id}", Delete);
        }

        private async static Task<IResult> GetAll(IMediator mediator)
        {
            var events = await mediator.Send(new GetEventsListQuery());
            return events.Any() ? Results.Ok(events) : Results.NoContent();
        }


        private async static Task<IResult> GetByID(IMediator mediator, Guid id)
        {
            try
            {
                var singleEvent = await mediator.Send(new GetEventDetailQuery { Id = id });
                return singleEvent != null ? Results.Ok(singleEvent) : Results.NotFound();

            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        }


        private async static Task<IResult> Create(IMediator mediator, CreateEventCommand createCommand)
        {
            try
            {
                var singleEvent = await mediator.Send(createCommand);

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



        private async static Task<IResult> Update(IMediator mediator, Guid id, UpdateEventCommand updateCommand)
        {
            try
            {
                updateCommand.Id = id;
                var singleEvent = await mediator.Send(updateCommand);
                return singleEvent != null ? Results.Created() : Results.Problem();

            }
            catch (ValidationException ex)
            {
                return Results.Problem(ex.ValidationErrors.FirstOrDefault());
            }
        }



        private async static Task<IResult> Delete(IMediator mediator, Guid id, DeleteEventCommand deleteCommand)
        {
            try
            {
                deleteCommand.Id = id;
                bool isDeleted = await mediator.Send(deleteCommand);

                if (isDeleted)
                {
                    return Results.NoContent();

                }
                else
                {
                    return Results.Problem();
                }

            }
            catch (ValidationException ex)
            {
                return Results.Problem(ex.ValidationErrors.FirstOrDefault());
            }
        }

    }
}
