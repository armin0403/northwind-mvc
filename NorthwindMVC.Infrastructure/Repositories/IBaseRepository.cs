using System.Linq.Expressions;


namespace NorthwindMVC.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get (int id);
        IEnumerable<TEntity> GetAll ();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicte);

        void Add (TEntity entity);
        void Update (TEntity entity);
        void Delete (TEntity entity);

    }
}
