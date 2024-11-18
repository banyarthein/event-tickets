using MediatR;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryQuery : IRequest<List<CategoryListModel>>
    {
    }
}
