using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Buzakov.App.Services
{

    public interface IRoleManagementService
    {

        IEnumerable<IdentityRole> GetAll( );

        IdentityRole Get(string id);

        void Delete(string id);

    }

}