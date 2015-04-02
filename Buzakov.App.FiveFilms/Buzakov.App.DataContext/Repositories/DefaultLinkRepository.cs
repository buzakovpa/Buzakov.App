using Buzakov.App.Models;
using System;

namespace Buzakov.App.DataContext.Repositories
{
    public class DefaultLinkRepository : BaseRepository<Link>, ILinkRepository
    {
        public DefaultLinkRepository( ApplicationContext context )
            : base( context )
        {

        }

        public Link Create( Link link )
        {
            if( link == null ) { throw new ArgumentNullException( "link" ); }
            if( link.Title == null ) { throw new ArgumentNullException( "Title" ); }
            if( link.Url == null ) { throw new ArgumentNullException( "Url" ); }

            return Insert( link );
        }
    }
}