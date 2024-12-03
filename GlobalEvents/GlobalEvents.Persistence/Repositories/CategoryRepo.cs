using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalEvents.Persistence.Repositories
{
    public class CategoryRepo : BaseRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(GlobalEventDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEventsAsync(bool includePastEvents)
        {
            var result = await _dbContext.Categories.Include(x => x.Events).ToListAsync();

            if (!includePastEvents)
            {
                result.ForEach(p =>
                {
                    if (p.Events != null)
                    {
                        p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today);
                    }
                });
            }

            return result;
        }

        public Task<bool> IsCategoryInUse(Guid Id)
        {
            var matches = _dbContext.Events.Any(e => e.CategoryId == Id);
            return Task.FromResult(matches);
        }
    }
}
