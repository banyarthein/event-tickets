using GlobalEvents.Application.Exceptions;
using GlobalEvents.Application.Features.Events.Commands.CreateEvent;
using GlobalEvents.Application.Features.Events.Commands.DeleteEvent;
using GlobalEvents.Application.Features.Events.Commands.UpdateEvent;
using GlobalEvents.Application.Features.Events.Queries.GetEventDetails;
using GlobalEvents.Application.Features.Events.Queries.GetEventList;
using GlobalEvents.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GlobalEvents.API.EndPoints
{
    public static class EventEndPoints
    {
        private static string moduleUrl = "";

        public static void EventEndPointsMapping(this WebApplication app, string routingRoot, string moduleName)
        {
            moduleUrl = routingRoot + moduleName;

            var moduleRoot = app.MapGroup(moduleUrl);

            moduleRoot.MapGet("/", GetAll)
                .WithName("GetEvents")
                .Produces<List<EventListModel>>(StatusCodes.Status200OK); ;

            moduleRoot.MapGet("/{id}", GetByID)
                .WithName("GetEvent")
                .Produces<EventDetailModel>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            moduleRoot.MapPost("/", Create)
                .WithName("CreateEvent")
                .Produces<Event>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);

            moduleRoot.MapPut("/{id}", Update)
                .WithName("UpdateEvent")
                .Produces<Event>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError);

            moduleRoot.MapDelete("/{id}", Delete)
                .WithName("DeleteEvent")
                .Produces<bool>(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError);
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


        private async static Task<IResult> Create(IMediator mediator, [FromBody] CreateEventCommand createCommand)
        {
            try
            {
                var singleItem = await mediator.Send(createCommand);

                if (singleItem != null)
                    return Results.Created($"{moduleUrl}/{singleItem.Id}", singleItem);
                else
                    return Results.Problem();

            }
            catch (ValidationException ex)
            {
                return Results.Problem(ex.ValidationErrors.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }



        private async static Task<IResult> Update(IMediator mediator, [FromBody] UpdateEventCommand updateCommand)
        {
            try
            {
                var singleItem = await mediator.Send(updateCommand);
                if (singleItem != null)
                {
                    return Results.Ok(singleItem);
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
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }



        private async static Task<IResult> Delete(IMediator mediator, Guid id)
        {
            try
            {
                var response = await mediator.Send(new DeleteEventCommand { Id = id });

                if (response.Success)
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
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}
