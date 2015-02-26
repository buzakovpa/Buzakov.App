using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Buzakov.App.DataContext
{

    public class ApplicationContext : IdentityDbContext<UserProfile>
    {

        public ApplicationContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<UserClaim> UserClaim { get; set; }

    }

}