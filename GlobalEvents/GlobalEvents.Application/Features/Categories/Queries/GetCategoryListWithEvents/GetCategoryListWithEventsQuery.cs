using MediatR;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class GetCategoryListWithEventsQuery: IRequest<List<CategoryEventListModel>>
    {
        public bool IncludeHistory { get; set; }
    }
}
