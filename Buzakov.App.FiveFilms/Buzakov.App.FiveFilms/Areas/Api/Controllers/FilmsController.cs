using System.Web.Http;

namespace Buzakov.App.FiveFilms.Areas.Api.Controllers
{

    [Authorize, RoutePrefix( "api/Films" )]
    public class FilmsController : ApiController
    {

    }

}