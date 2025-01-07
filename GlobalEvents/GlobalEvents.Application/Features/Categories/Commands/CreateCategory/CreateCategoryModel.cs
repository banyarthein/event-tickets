namespace GlobalEvents.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
