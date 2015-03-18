namespace Buzakov.App.DataContext.EntityManager
{

    public class EntityManager : IEntityManager
    {

        private readonly ApplicationContext _context;

        public EntityManager( ApplicationContext context )
        {
            _context = context;
        }

        public ApplicationContext GetContext( )
        {
            return _context;
        }

        public void Commit( )
        {
            _context.SaveChanges( );
        }

        public void Dispose( )
        {
            if( _context != null ) {
                _context.Dispose( );
            }
        }

    }

}