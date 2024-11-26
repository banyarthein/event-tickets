using GlobalEvents.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandResponse: BaseResponse
    {
        public UpdateCategoryCommandResponse() : base()
        {
            
        }
        public bool isUpdated { get; set; }

        public UpdateCategoryModel Category { get; set; }

    }
}
