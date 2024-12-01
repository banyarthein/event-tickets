using GlobalEvents.Domain.Entities;

namespace GlobalEvents.Application.Interface.Persistence
{
    public interface IOrderRepo : IAsyncRepository<Order>
    {
    }
}
