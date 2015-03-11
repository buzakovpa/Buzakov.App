using System;
using System.Web.Mvc;

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

        public ActionResult Os( )
        {
            var deviceType = ( Request.Browser.IsMobileDevice ? "Mobile" : "Desktop" );
            var userAgent = Request.UserAgent;

            var content = String.Format("Type: {0}<br/>" + "UserAgent: {1}", deviceType, userAgent);

            return Content(content);
        }

    }

}