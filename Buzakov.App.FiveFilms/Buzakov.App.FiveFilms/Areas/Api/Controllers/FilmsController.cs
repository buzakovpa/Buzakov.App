using System;
using System.Collections.Generic;
using System.Web.Http;

using Buzakov.App.Models;
using Buzakov.App.Services;

namespace Buzakov.App.FiveFilms.Areas.Api.Controllers
{

    [Authorize, RoutePrefix( "api/Films" )]
    public class FilmsController : ApiController
    {

        public FilmsController(IFilmManager filmManager)
        {
            
        }

        public List<Film> Get( )
        {
            throw new NotImplementedException();
        }

    }

}