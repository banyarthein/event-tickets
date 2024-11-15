using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<CategoryListModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _categoryRepo;

        public GetCategoryQueryHandler(IMapper mapper, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<List<CategoryListModel>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryRepo.ListAllAsync();
            return _mapper.Map<List<CategoryListModel>>(categoryList);
        }
    }
}
