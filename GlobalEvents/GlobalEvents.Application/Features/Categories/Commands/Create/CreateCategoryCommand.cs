using MediatR;

namespace GlobalEvents.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
