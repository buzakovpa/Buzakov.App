using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

using Buzakov.App.DataContext;
using Buzakov.App.Services;

namespace Buzakov.App.FiveFilms.Areas.Api.Controllers
{

    [System.Web.Http.Authorize, System.Web.Http.RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {

        private readonly IUserManagementService _userService;

        public UsersController( )
        {
            _userService = DependencyResolver.Current.GetService<IUserManagementService>( );
        }

        public IEnumerable<UserProfile> Get( )
        {
            return _userService.GetAll( );
        }

        public UserProfile Get(string id)
        {
            return _userService.Get(id);
        }

        [System.Web.Http.Route("Delete")]
        public void Delete(string id)
        {
            _userService.Delete(id);
        }

    }

}