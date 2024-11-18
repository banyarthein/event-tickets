using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class GetCategoryListWithEventsQueryHandler : IRequestHandler<GetCategoryListWithEventsQuery, List<CategoryEventListModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _categoryRepo;

        public GetCategoryListWithEventsQueryHandler(IMapper mapper, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<List<CategoryEventListModel>> Handle(GetCategoryListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepo.GetCategoriesWithEventsAsync(request.IncludeHistory);

            return _mapper.Map<List<CategoryEventListModel>>(list);
        }
    }
}
