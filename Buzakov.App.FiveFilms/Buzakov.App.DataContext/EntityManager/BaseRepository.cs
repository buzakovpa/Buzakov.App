using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Buzakov.App.DataContext.EntityManager
{

    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, new( )
    {

        private IDbSet<TEntity> _dbSet;
        private IEntityManager _entityManager;

        public void SetEntityManager(IEntityManager entityManager)
        {
            _entityManager = entityManager;
            _dbSet = _entityManager.GetContext( ).Set<TEntity>( );
        }

        public virtual TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity Find( string id )
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity Insert( TEntity entity )
        {
            return _dbSet.Add(entity);
        }

        public virtual TEntity Update( TEntity entity )
        {
            _dbSet.AddOrUpdate(entity);

            return entity;
        }

        public virtual void Delete( TEntity entity )
        {
            _dbSet.Remove(entity);
        }

        public virtual IQueryable<TEntity> AsQueryable( )
        {
            return _dbSet.AsQueryable( );
        }

    }

}