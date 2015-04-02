using System.Linq;

namespace Buzakov.App.DataContext
{
    public interface IRepository<TEntity>
    {
        TEntity Find( object id );

        IQueryable<TEntity> AsQueryable();
        
        TEntity Insert(TEntity entity);
        void Delete( TEntity entity );
    }
}