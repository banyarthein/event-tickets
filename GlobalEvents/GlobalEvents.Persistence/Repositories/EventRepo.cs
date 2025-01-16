using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalEvents.Persistence.Repositories
{
    public class EventRepo : BaseRepository<Event>, IEventRepo
    {


        public EventRepo(GlobalEventDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventNameAndDateUniqueAsync(string name, DateTime eventDate)
        {
            //var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && (e.Date == eventDate.Date));
            //var matches = _dbContext.Events.Any(e => e.Name.Equals(name));
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && (EF.Functions.DateDiffDay(e.Date, eventDate) == 0));
            return Task.FromResult(matches);
        }

        public Task<bool> IsEventNameAndDateUniqueForUpdateAsync(Guid id, string name, DateTime eventDate)
        {
            //var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && (e.Date == eventDate.Date));
            //var matches = _dbContext.Events.Any(e => e.Name.Equals(name));
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && (e.Id != id) && (EF.Functions.DateDiffDay(e.Date, eventDate) == 0));
            return Task.FromResult(matches);
        }
    }
}

