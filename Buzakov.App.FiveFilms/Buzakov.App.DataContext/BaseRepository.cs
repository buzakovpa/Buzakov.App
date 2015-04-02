using Buzakov.App.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Buzakov.App.DataContext
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity :  class, ISoftDelete
    {
        private ApplicationContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public BaseRepository( ApplicationContext dbContext )
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>( );
        }

        public TEntity Find( object id )
        {
            return _dbSet.Find( id );
        }

        public IQueryable<TEntity> AsQueryable( )
        {
            return _dbSet.AsQueryable( );
        }

        public TEntity Insert( TEntity entity )
        {
            return _dbSet.Add( entity );
        }

        public void Delete( TEntity entity )
        {
            entity.IsDeleted = true;
            _dbContext.Entry<TEntity>( entity ).State = EntityState.Modified;
        }
    }
}