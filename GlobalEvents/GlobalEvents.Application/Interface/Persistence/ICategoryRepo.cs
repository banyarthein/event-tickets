using GlobalEvents.Domain.Entities;

namespace GlobalEvents.Application.Interface.Persistence
{
    public interface ICategoryRepo : IAsyncRepo<Category>
    {
        Task<List<Category>> GetCategoriesWithEventsAsync(bool includePastEvents);

        Task<bool> IsCategoryInUseAsync(Guid Id);
    }
}
