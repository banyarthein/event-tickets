using GlobalEvents.Domain.Entities;

namespace GlobalEvents.Application.Interface.Persistence
{
    public interface IOrderRepo : IAsyncRepository<Order>
    {
        Task<List<Order>> GetOrdersByEventIdAsync(Guid eventId);
        Task<List<Order>> GetOrdersByCategoryIdAsync(Guid eventId);
    }
}
