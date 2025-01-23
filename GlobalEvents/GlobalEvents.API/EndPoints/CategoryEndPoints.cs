using GlobalEvents.Application.Exceptions;
using GlobalEvents.Application.Features.Categories.Commands.CreateCategory;
using GlobalEvents.Application.Features.Categories.Commands.DeleteCategory;
using GlobalEvents.Application.Features.Categories.Commands.UpdateCategory;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryDetails;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryExport;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GlobalEvents.API.EndPoints
{
    public static class CategoryEndPoints
    {
        private static string moduleUrl = "";

        public static void CategoryEndPointsMapping(this WebApplication app, string routingRoot, string moduleName)
        {
            moduleUrl = routingRoot + moduleName;

            var moduleRoot = app.MapGroup(moduleUrl);

            moduleRoot.MapGet("/", GetAll)
                .WithName("GetCategories")
                .Produces<List<CategoryListModel>>(StatusCodes.Status200OK);

            moduleRoot.MapGet("/{id}", GetByID)
                .WithName("GetCategory")
                .Produces<CategoryDetailModel>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);


            moduleRoot.MapGet("/export", Export)
                .WithName("ExportCategories")
                .Produces<List<CategoryListModel>>(StatusCodes.Status200OK);


            moduleRoot.MapPost("/", Create)
                .WithName("CreateCategory")
                .Produces<CreateCategoryCommandResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);

            moduleRoot.MapPut("/", Update)
                .WithName("UpdateCategory")
                .Produces<UpdateCategoryCommandResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError);

            moduleRoot.MapDelete("/{id}", Delete)
                .WithName("DeleteCategory")
                .Produces<bool>(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError);
        }

        private async static Task<IResult> GetAll(IMediator mediator)
        {
            var dataSet = await mediator.Send(new GetCategoryQuery());
            return dataSet.Any() ? Results.Ok(dataSet) : Results.NoContent();
        }


        private async static Task<IResult> GetByID(IMediator mediator, Guid id)
        {
            try
            {
                var singleItem = await mediator.Send(new GetCategoryDetailQuery { Id = id });
                return singleItem != null ? Results.Ok(singleItem) : Results.NotFound();

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


        private async static Task<IResult> Create(IMediator mediator, [FromBody] CreateCategoryCommand createCommand)
        {
            try
            {
                var singleItem = await mediator.Send(createCommand);

                if (singleItem != null && singleItem.Category != null)
                    return Results.CreatedAtRoute("GetCategory", new { id = singleItem.Category.Id }, singleItem);
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


        private async static Task<IResult> Update(IMediator mediator, [FromBody] UpdateCategoryCommand updateCommand)
        {
            try
            {
                var singleItem = await mediator.Send(updateCommand);

                if (singleItem != null && singleItem.Category != null)
                    return Results.Ok(singleItem);
                else
                    return Results.Problem();

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
            catch (NotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private async static Task<IResult> Export(IMediator mediator)
        {
            var exportFile = await mediator.Send(new GetCategoryExportQuery());
            return Results.File(exportFile.Data, exportFile.ContentType, exportFile.FileName);
        }

    }
}
