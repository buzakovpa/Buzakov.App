using System;
using System.Collections.Generic;
using System.Data.Entity.Core;

using Microsoft.AspNet.Identity.EntityFramework;

namespace Buzakov.App.Services
{

    public interface IRoleManagementService
    {

        IEnumerable<IdentityRole> GetAll( );

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectNotFoundException"></exception>
        IdentityRole Details( string id );

        /// <exception cref="ArgumentNullException"></exception>
        IdentityRole Create( string name );

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectNotFoundException"></exception>
        void Delete( string id );

    }

}