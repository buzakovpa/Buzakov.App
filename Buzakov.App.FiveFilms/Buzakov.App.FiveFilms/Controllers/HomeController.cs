
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.WebPages;

using Microsoft.AspNet.Identity;

namespace Buzakov.App.FiveFilms.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index( )
        {
            ViewBag.Title = "Home Page";
            return View( );
        }
        
        public ActionResult Protocol( )
        {
            return Redirect("buzakov-5films:Show");
        }

        public ActionResult Os()
        {
            return Content("Type: " + (Request.Browser.IsMobileDevice ? "Mobile" : "Desktop") );
        }

    }

}