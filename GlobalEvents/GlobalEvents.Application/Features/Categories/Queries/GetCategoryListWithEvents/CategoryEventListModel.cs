using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class CategoryEventListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<CategoryEventModel> Events { get; set; } = default;
    }
}
