using System.Linq;

namespace Buzakov.App.DataContext.EntityManager
{

    public interface IRepository
    {

        void SetEntityManager( IEntityManager entityManager );

    }

    public interface IRepository<TEntity> : IRepository
    {

        TEntity Find( object id );

        TEntity Insert( TEntity entity );
        TEntity Update( TEntity entity );
        void Delete( TEntity entity );

        IQueryable<TEntity> AsQueryable( );

    }

}