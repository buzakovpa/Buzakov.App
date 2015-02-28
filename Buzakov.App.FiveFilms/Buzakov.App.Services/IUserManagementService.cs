using System;
using System.Data.Entity.Core;
using System.Collections.Generic;

using Buzakov.App.DataContext;

namespace Buzakov.App.Services
{

    public interface IUserManagementService
    {

        IEnumerable<UserProfile> GetAll( );

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectNotFoundException"></exception>
        UserProfile Details(string id);

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectNotFoundException"></exception>
        UserProfile AssineRole(string userId, string roleId);

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectNotFoundException"></exception>
        void Delete(string id);

    }

}