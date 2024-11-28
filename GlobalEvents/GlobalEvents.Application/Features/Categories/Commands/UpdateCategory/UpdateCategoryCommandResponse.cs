using GlobalEvents.Application.Responses;

namespace GlobalEvents.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandResponse : BaseResponse
    {
        public UpdateCategoryCommandResponse() : base()
        {

        }

        public UpdateCategoryModel Category { get; set; }

    }
}
