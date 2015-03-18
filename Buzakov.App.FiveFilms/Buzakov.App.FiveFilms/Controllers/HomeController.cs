using System.Web.Mvc;

using Buzakov.App.FiveFilms.Infrastructure.Helpers;

namespace Buzakov.App.FiveFilms.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index( )
        {
            ViewBag.Title = "Home Page";
            return View( );
        }

        public ActionResult Film( string id )
        {
            if( this.IsWindowsPhone( ) ) {
                var url = string.Format("buzakov-5films:Film/{0}", id);

                return Redirect(url);
            }

            return Content(id);
        }

    }

}