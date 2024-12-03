using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Persistence.Repositories
{
    public class EventRepo : BaseRepository<Event>, IEventRepo
    {


        public EventRepo(GlobalEventDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventNameAndDateUniqueAsync(string name, DateTime eventDate)
        {
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Equals(eventDate.Date));
            return Task.FromResult(matches);
        }
    }
}
