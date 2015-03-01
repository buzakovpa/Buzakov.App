using System.Security.Claims;
using System.Threading.Tasks;

using Buzakov.App.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Buzakov.App.DataContext
{

    public class UserProfile : IdentityUser, ISoftDelete
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserProfile, string> manager, string authenticationType)
        {
            return await manager.CreateIdentityAsync(this, authenticationType);
        }

        public bool IsDeleted { get; set; }

    }

}