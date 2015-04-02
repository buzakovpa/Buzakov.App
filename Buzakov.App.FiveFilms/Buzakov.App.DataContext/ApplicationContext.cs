using System.Data.Entity;
using Buzakov.App.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Buzakov.App.DataContext.Configurations;

namespace Buzakov.App.DataContext
{

    public class ApplicationContext : IdentityDbContext<UserProfile>
    {

        public ApplicationContext( )
            : base( "DefaultConnection" )
        {
        }

        public IDbSet<Link> DataLinks { get; set; }
        public IDbSet<Film> Films { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.Configurations.Add( new FilmConfiguration( ) );
            modelBuilder.Configurations.Add( new LinkConfiguration( ) );
        }
    }
}