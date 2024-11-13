namespace GlobalEvents.Application.Interface.Persistence
{
    public interface IAsyncRepo<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListByPage(int pageSize, int pageIndex);
        Task<T> AddAsync(Task entity);
        Task UpdateAsync(Task entity);
        Task DeleteAsync(Task entity);
    }
}
