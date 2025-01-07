using MediatR;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailQuery : IRequest<CategoryDetailModel>
    {
        public Guid Id { get; set; }
    }
}
