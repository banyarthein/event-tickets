using GlobalEvents.Domain.Entities;

namespace GlobalEvents.Application.Interface.Persistence
{
    public interface IEventRepo : IAsyncRepo<Event>
    {
    }
}
