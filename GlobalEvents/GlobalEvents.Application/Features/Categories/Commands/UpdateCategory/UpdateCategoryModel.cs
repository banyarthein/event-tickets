namespace GlobalEvents.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
