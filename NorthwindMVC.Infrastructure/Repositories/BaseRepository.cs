using System.Linq.Expressions;
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
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicte)
        {
            return _dbContext.Set<TEntity>().Where(predicte);
        }

        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
           _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
