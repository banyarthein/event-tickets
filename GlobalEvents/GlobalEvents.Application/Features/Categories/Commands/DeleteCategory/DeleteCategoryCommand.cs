using MediatR;

namespace GlobalEvents.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand: IRequest<DeleteCategoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
