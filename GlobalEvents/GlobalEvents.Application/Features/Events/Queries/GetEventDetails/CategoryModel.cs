using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Events.Queries.GetEventDetails
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
