using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;

namespace GlobalEvents.Persistence.Repositories
{
    public class OrderRepo : BaseRepository<Order>, IOrderRepo
    {
        public OrderRepo(GlobalEventDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Order>> GetOrdersByCategoryIdAsync(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByEventIdAsync(Guid eventId)
        {
            throw new NotImplementedException();
        }
    }
}
