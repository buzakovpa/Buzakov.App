using System;
using System.Web.Http;
using System.Linq;
using System.Linq.Expressions;
using Buzakov.App.Models;
using Buzakov.App.DataContext;
using Buzakov.App.Mappers.Models;
using Buzakov.App.DataContext.Repositories;

namespace Buzakov.App.FiveFilms.Areas.Api.Controllers
{
    [Authorize, RoutePrefix("api/Film")]
    public class FilmController : ApiController
    {
        private IFilmRepository _filmRepository;
        private IEntityManager _entityManager;

        public FilmController(IFilmRepository filmRepository, IEntityManager entityManager)
        {
            _filmRepository = filmRepository;
            _entityManager = entityManager;
        }

        [Route("Rand")]
        public IHttpActionResult GetRand( )
        {
            try {
                var resultList = _filmRepository.RandMapped<FilmMapper>(1);
                if (resultList.Any( )) {
                    return Ok(resultList.First( ));
                }
                return NotFound( );
            } catch (Exception ex) {
                return BadRequest(ex.ToString( ));
            }
        }

        [Route("Rands")]
        public IHttpActionResult GetRands(int limit = 5)
        {
            try {
                var resultList = _filmRepository.RandMapped<FilmMapper>(limit);
                if (resultList.Any( )) {
                    return Ok(resultList);
                }
                return NotFound( );
            } catch (Exception ex) {
                return BadRequest(ex.ToString( ));
            }
        }

        [Route("Search")]
        public IHttpActionResult GetSearch(string query, int limit = 20)
        {
            try {
                var resultList = _filmRepository.SearchMapped<FilmMapper>(query, limit);
                if (resultList.Any( )) {
                    return Ok(resultList);
                }
                return NotFound( );
            } catch (Exception ex) {
                return BadRequest(ex.ToString( ));
            }
        }

        [Authorize(Roles = "Administrator"), Route("Create")]
        public IHttpActionResult Post(Film film)
        {
            try {
                var entity = _filmRepository.Create(film);
                _entityManager.Commit( );

                return Ok(entity);
            } catch (Exception ex) {
                return BadRequest(ex.ToString( ));
            }
        }
    }
}