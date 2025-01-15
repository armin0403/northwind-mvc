using System.Linq.Expressions;


namespace NorthwindMVC.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get (int id);
        Task<TEntity> GetByIdAsync (int id);
        Task<IEnumerable<TEntity>> GetAllList();
        IQueryable<TEntity> GetAllQueryable ();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicte);

        Task AddAsync (TEntity entity);
        Task UpdateAsync (TEntity entity);
        Task DeleteAsync (TEntity entity);
        Task <bool> AnyAsync (Expression<Func<TEntity, bool>> predicate);

    }
}
