namespace Buzakov.App.DataContext
{
    public class DefaultEntityManager : IEntityManager
    {

        private ApplicationContext _dbContext;

        public DefaultEntityManager( ApplicationContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void Commit( )
        {
            _dbContext.SaveChanges( );
        }
    }
}