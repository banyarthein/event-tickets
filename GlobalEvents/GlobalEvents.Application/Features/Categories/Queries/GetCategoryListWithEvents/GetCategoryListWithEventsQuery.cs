using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class GetCategoryListWithEventsQuery: IRequest<List<CategoryEventListModel>>
    {
        public bool IncludeHistory { get; set; }
    }
}
