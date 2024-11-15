using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryQuery : IRequest<List<CategoryListModel>>
    {
    }
}
