namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class CategoryEventModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
    }
}
