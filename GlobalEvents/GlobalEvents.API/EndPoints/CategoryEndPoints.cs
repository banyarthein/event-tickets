using GlobalEvents.Application.Exceptions;
using GlobalEvents.Application.Features.Categories.Commands.CreateCategory;
using GlobalEvents.Application.Features.Categories.Commands.DeleteCategory;
using GlobalEvents.Application.Features.Categories.Commands.UpdateCategory;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryDetails;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryList;
using MediatR;

namespace GlobalEvents.API.EndPoints
{
    public static class CategoryEndPoints
    {
        private static string moduleUrl = "";

        public static void CategoryEndPointsMapping(this WebApplication app, string routingRoot, string moduleName)
        {
            moduleUrl = routingRoot + moduleName;

            var moduleRoot = app.MapGroup(moduleUrl);

            moduleRoot.MapGet("/", GetAll);

            moduleRoot.MapGet("/{id}", GetByID);

            moduleRoot.MapPost("/", Create);

            moduleRoot.MapPut("/", Update);

            moduleRoot.MapDelete("/{id}", Delete);
        }

        private async static Task<IResult> GetAll(IMediator mediator)
        {
            var dataSet = await mediator.Send(new GetCategoryQuery());
            return dataSet.Any() ? Results.Ok(dataSet) : Results.NoContent();
        }


        private async static Task<IResult> GetByID(IMediator mediator, Guid id)
        {
            var singleItem = await mediator.Send(new GetCategoryDetailQuery { Id = id });
            return singleItem != null ? Results.Ok(singleItem) : Results.NotFound();
        }


        private async static Task<IResult> Create(IMediator mediator, CreateCategoryCommand createCommand)
        {
            try
            {
                var singleItem = await mediator.Send(createCommand);

                if (singleItem != null)
                    return Results.Created($"{moduleUrl}/{singleItem.Category.Id}", singleItem);
                else
                    return Results.Problem();

            }
            catch (ValidationException ex)
            {
                return Results.Problem(ex.ValidationErrors.FirstOrDefault());
            }
        }


        private async static Task<IResult> Update(IMediator mediator, UpdateCategoryCommand updateCommand)
        {
            try
            {
                var singleItem = await mediator.Send(updateCommand);
                return singleItem != null ? Results.Ok() : Results.Problem();

            }
            catch (ValidationException ex)
            {
                return Results.Problem(ex.ValidationErrors.FirstOrDefault());
            }

        }


        private async static Task<IResult> Delete(IMediator mediator, Guid id)
        {
            try
            {
                var deleteResponse = await mediator.Send(new DeleteCategoryCommand { Id = id });
                if (deleteResponse != null && deleteResponse.Success)
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
