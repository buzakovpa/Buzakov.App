using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

using Buzakov.App.Services;

namespace Buzakov.App.FiveFilms.Areas.Api.Controllers
{

    [System.Web.Http.Authorize, System.Web.Http.RoutePrefix("api/Roles")]
    public class RolesController : ApiController
    {

        private readonly IRoleManagementService _roleService;

        public RolesController()
        {
            _roleService = DependencyResolver.Current.GetService<IRoleManagementService>();
        }

        public IEnumerable<IdentityRole> Get()
        {
            return _roleService.GetAll();
        }

        public IdentityRole Get(string id)
        {
            return _roleService.Get(id);
        }

        [System.Web.Http.Route("Delete")]
        public void Delete(string id)
        {
            _roleService.Delete(id);
        }

    }

}