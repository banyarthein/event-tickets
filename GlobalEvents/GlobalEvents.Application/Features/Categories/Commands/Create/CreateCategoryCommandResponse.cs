using GlobalEvents.Application.Responses;

namespace GlobalEvents.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandResponse: BaseResponse
    {
        public CreateCategoryCommandResponse(): base()
        {
            
        }

        public CreateCategoryModel Category { get; set; } = default;
    }
}
