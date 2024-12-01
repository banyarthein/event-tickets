using GlobalEvents.Domain.Entities;

namespace GlobalEvents.Application.Interface.Persistence
{
    public interface IEventRepo : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUniqueAsync(string name, DateTime date);
    }
}
