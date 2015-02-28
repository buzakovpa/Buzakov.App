using System.Collections.Generic;
using System.Web.Http;

using Buzakov.App.Services;

using Microsoft.AspNet.Identity.EntityFramework;

namespace Buzakov.App.FiveFilms.Areas.Api.Controllers
{
    [Authorize, RoutePrefix( "api/Roles" )]
    public class RolesController : ApiController
    {
        
        private readonly IRoleManagementService _roleService;

        public RolesController( )
        {
            _roleService = ( IRoleManagementService )System.Web.Mvc.DependencyResolver.Current.GetService(typeof( IRoleManagementService ));
        }

        public IEnumerable<IdentityRole> Get( )
        {
            return _roleService.GetAll( );
        }

        public IdentityRole Get( string id )
        {
            return _roleService.Details(id);
        }

        [Route("Create")]
        public IdentityRole Post([FromBody]string name)
        {
            return _roleService.Create(name);
        }

        [Route( "{id}/Delete" )]
        public void Delete( string id )
        {
            _roleService.Delete(id);
        }
    }
}