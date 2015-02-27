using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

using Buzakov.App.DataContext;

namespace Buzakov.App.Services
{

    public interface IUserManagementService
    {

        IEnumerable<UserProfile> GetAll( );

        UserProfile Get(string id);

        UserProfile AssineRole(string userId, IdentityRole role);

        void Delete(string id);

    }

}