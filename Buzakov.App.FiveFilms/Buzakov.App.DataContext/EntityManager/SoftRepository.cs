using System.Linq;

using Buzakov.App.Models;

namespace Buzakov.App.DataContext.EntityManager
{

    public class SoftRepository<TEntity> : BaseRepository<TEntity> where TEntity : class, ISoftDelete, new( )
    {

        public override void Delete( TEntity entity )
        {
            entity.IsDeleted = true;
        }

        public override IQueryable<TEntity> AsQueryable( )
        {
            return base.AsQueryable( ).Where(a => a.IsDeleted != true);
        }

    }

}