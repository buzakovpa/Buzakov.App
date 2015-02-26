using System.Collections.Generic;
using System.Web.Http;

using Buzakov.App.DataContext;
using Buzakov.App.DataContext.EntityManager;
using Buzakov.App.Repositories;

namespace Buzakov.App.FiveFilms.Controllers
{

    [Authorize, RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {

        private readonly UserProfileRepository _userProfileRepository;

        public UsersController(IEntityManager entityManager)
        {
            _userProfileRepository = entityManager.GetRepository<UserProfileRepository>( );
        }

        public IEnumerable<UserProfile> Get( )
        {
            return _userProfileRepository.AsQueryable( );
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