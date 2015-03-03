using System;
using System.Collections.Generic;
using System.Web.Http;

using AutoMapper;

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
        public IDataLink Post( [FromBody] DataLinkBindingModel model )
        {
            if( model != null ) {
                var link = Mapper.Map<DataLink>(model);
                return _dataLinkService.Create(link);
            }
            throw new ArgumentNullException("model");
        }

        [Authorize( Roles = "Administrator" )]
        public IDataLink Put( [FromBody] DataLinkBindingModel model )
        {
            if( model != null ) {
                var link = Mapper.Map<DataLink>(model);
                return _dataLinkService.Update(link);
            }
            throw new ArgumentNullException("model");
        }

        [Authorize( Roles = "Administrator" )]
        public void Delete( int id )
        {
            _dataLinkService.Delete(id);
        }

    }

}