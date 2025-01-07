using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailModel>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _categoryRepo;

        public GetCategoryDetailQueryHandler(IMapper mapper, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<CategoryDetailModel> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepo.GetByIdAsync(request.Id);
            return _mapper.Map<CategoryDetailModel>(category);
        }
    }
}
