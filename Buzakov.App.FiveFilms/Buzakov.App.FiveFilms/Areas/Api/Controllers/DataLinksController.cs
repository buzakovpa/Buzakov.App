using System.Collections.Generic;
using System.Web.Http;

using Buzakov.App.FiveFilms.Areas.Api.Models;
using Buzakov.App.Models;
using Buzakov.App.Services;

namespace Buzakov.App.FiveFilms.Areas.Api.Controllers
{

    [Authorize, RoutePrefix( "api/DataLinks" )]
    public class DataLinksController : ApiController
    {

        private readonly IDataLinkManagementService _dataLinkService;

        public DataLinksController( )
        {
            _dataLinkService = ( IDataLinkManagementService )System.Web.Mvc.DependencyResolver.Current.GetService(typeof( IDataLinkManagementService ));
        }

        public IEnumerable<DataLink> Get( )
        {
            return _dataLinkService.GetAll( );
        }

        public DataLink Get( int id )
        {
            return _dataLinkService.Details(id);
        }

        [Authorize( Roles = "Administrator" )]
        public IDataLink Post( [FromBody] DataLinkBindingModel link )
        {
            return _dataLinkService.Create(link);
        }

        [Authorize( Roles = "Administrator" )]
        public IDataLink Put( [FromBody] DataLinkBindingModel link )
        {
            return _dataLinkService.Update(link);
        }

        [Authorize( Roles = "Administrator" )]
        public void Delete( int id )
        {
            _dataLinkService.Delete(id);
        }

    }

}