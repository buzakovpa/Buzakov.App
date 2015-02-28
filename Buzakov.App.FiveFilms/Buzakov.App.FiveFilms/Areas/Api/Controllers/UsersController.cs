using System.Collections.Generic;
using System.Web.Http;

using Buzakov.App.DataContext;
using Buzakov.App.Services;

namespace Buzakov.App.FiveFilms.Areas.Api.Controllers
{

    [Authorize, RoutePrefix( "api/Users" )]
    public class UsersController : ApiController
    {

        private readonly IUserManagementService _userService;

        public UsersController( )
        {
            _userService = ( IUserManagementService )System.Web.Mvc.DependencyResolver.Current.GetService(typeof( IUserManagementService ));
        }

        public IEnumerable<UserProfile> Get( )
        {
            return _userService.GetAll( );
        }

        public UserProfile Get( string id )
        {
            return _userService.Details(id);
        }

        [Route("{id}/AssineRole/{roleId}")]
        public UserProfile Put(string id, string roleId)
        {
            return _userService.AssineRole(id, roleId);
        }

        [Route( "{id}/Delete" )]
        public void Delete( string id )
        {
            _userService.Delete(id);
        }

    }

}