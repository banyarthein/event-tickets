using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
