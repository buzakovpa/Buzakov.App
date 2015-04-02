using System.Web.Mvc;
using Buzakov.App.FiveFilms.Infrastructure.Helpers;
using Buzakov.App.DataContext.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using Buzakov.App.Mappers.Models;

namespace Buzakov.App.FiveFilms.Controllers
{

    public class HomeController : Controller
    {
        private IFilmRepository _filmRepository;

        public HomeController(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public ActionResult Index( )
        {
            ViewBag.Title = "Home Page";
            return View( );
        }

        public ActionResult Daily(string id)
        {
            if (id == null) {
                ModelState.AddModelError("id", new ArgumentNullException("id"));
            }
            if (ModelState.IsValid) {
                if (this.IsWindowsPhone( )) {
                    var url = string.Format("buzakov-5films:Film/{0}", id);

                    return Redirect(url);
                }
                return View( );
            }
            return HttpNotFound( );
        }

        public ActionResult Personal( )
        {
            var entities = _filmRepository.RandMapped<FilmMapper>(1);
            if (entities == null && !entities.Any( )) {
                return HttpNotFound( );
            }

            var entity = entities.First( );

            if (this.IsWindowsPhone( )) {
                var url = string.Format("buzakov-5films:Film/{0}", entity.Id);

                return Redirect(url);
            }

            return View( );
        }

    }

}