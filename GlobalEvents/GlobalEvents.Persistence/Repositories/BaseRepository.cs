using GlobalEvents.Application.Interface.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalEvents.Persistence;
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


        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
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

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
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
            catch(Exception ex)
            {
                isOk = false;
            }   

            return isOk;
        }


    }
}
