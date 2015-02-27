﻿using System.Data.Entity;
using System.Linq;

using Buzakov.App.Models;

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

        public TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Find(string id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Insert(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public TEntity Update(TEntity entity)
        {
            var dbContext = _entityManager.GetContext( );
            dbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity is ISoftDelete) {
                var entityWithSoftDelete = entity as ISoftDelete;
                entityWithSoftDelete.IsDeleted = true;
            } else {
                _dbSet.Remove(entity);
            }
        }

        public IQueryable<TEntity> AsQueryable( )
        {
            var query = _dbSet.AsQueryable( );

            var tmpEntity = new TEntity( );
            if (tmpEntity is ISoftDelete) {
                return query.Where(a => (a is ISoftDelete) && ((ISoftDelete)a).IsDeleted != true);
            }

            return query;
        }

    }

}