using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Buzakov.App.DataContext
{

    public class UserProfile : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserProfile, string> manager, string authenticationType)
        {
            return await manager.CreateIdentityAsync(this, authenticationType);
        }

    }

}