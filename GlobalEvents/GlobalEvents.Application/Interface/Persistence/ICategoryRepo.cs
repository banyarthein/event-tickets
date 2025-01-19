using GlobalEvents.Domain.Entities;

namespace GlobalEvents.Application.Interface.Persistence
{
    public interface ICategoryRepo : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEventsAsync(bool includePastEvents);

        Task<bool> IsCategoryInUse(Guid Id);

        Task<bool> IsCategoryNameUniqueAsync(string name);
        Task<bool> IsCategoryNameUniqueForUpdateAsync(Guid id, string name);
    }
}
