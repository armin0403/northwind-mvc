using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Infrastucture;

namespace NorthwindMVC.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly NorthwindDbContext _dbContext;

        public BaseRepository(NorthwindDbContext dbContext) 
        {
           _dbContext = dbContext;
        }
        public async Task AddAsync(TEntity entity)
        {
           await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicte)
        {
            return _dbContext.Set<TEntity>().Where(predicte);
        }

        public async Task<TEntity> Get(int id)
        {
           return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
                
        public async Task UpdateAsync(TEntity entity)
        {
           _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
