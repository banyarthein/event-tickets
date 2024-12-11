using GlobalEvents.Application.Exceptions;
using GlobalEvents.Application.Interface.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GlobalEvents.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly GlobalEventDbContext _dbContext;

        public BaseRepository(GlobalEventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsIDExists(Guid id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);
            return (result != null);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);
            if (result == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            return result;
        }


        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListByPage(int pageSize, int pageIndex)
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(entity).ReloadAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            bool isOk = false;
            try
            {
                _dbContext.Set<T>().Remove(entity);
                int rowEffected = await _dbContext.SaveChangesAsync();

                return (rowEffected != 0);

            }
            catch (Exception ex)
            {
                isOk = false;
            }

            return isOk;
        }


    }
}
