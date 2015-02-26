using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI;
using Buzakov.App.DataContext;
using Buzakov.App.DataContext.EntityManager;
using Buzakov.App.Repositories;

namespace Buzakov.App.FiveFilms.Controllers
{

    [System.Web.Http.Authorize, System.Web.Http.RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {

        private readonly UserProfileRepository _userProfileRepository;

        public UsersController( )
        {
            var entityManager = DependencyResolver.Current.GetService<IEntityManager>( );
            _userProfileRepository = entityManager.GetRepository<UserProfileRepository>();
        }


        public List<UserProfile> Get( )
        {
            return _userProfileRepository.AsQueryable( ).ToList( );
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value) {}

        // PUT api/values/5
        public void Put(int id, [FromBody] string value) {}

        // DELETE api/values/5
        public void Delete(int id) {}

    }

}