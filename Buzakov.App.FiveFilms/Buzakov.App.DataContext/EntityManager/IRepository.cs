using System.Linq;
using System.Linq.Expressions;

namespace Buzakov.App.DataContext.EntityManager
{

    public interface IRepository
    {

        void SetEntityManager(IEntityManager entityManager);

    }

    public interface IRepository<TEntity> : IRepository
    {

        TEntity Find(string id);
        TEntity Find(int id);

        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);

        IQueryable<TEntity> AsQueryable();

    }

}