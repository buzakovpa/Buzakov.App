using System;
using System.Collections.Generic;
using System.Data.Entity.Core;

using Buzakov.App.Models;

namespace Buzakov.App.Services
{

    public interface IDataLinkManager
    {

        IEnumerable<DataLink> GetAll( );

        /// <exception cref="ObjectNotFoundException"></exception>
        DataLink Details( int id );

        /// <exception cref="ArgumentNullException"></exception>
        DataLink Create( IDataLink link );

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectNotFoundException"></exception>
        DataLink Update( IDataLink link );

        /// <exception cref="ObjectNotFoundException"></exception>
        void Delete( int id );

    }

}