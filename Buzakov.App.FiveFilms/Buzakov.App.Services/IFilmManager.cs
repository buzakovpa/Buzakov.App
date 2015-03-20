using System.Collections.Generic;

using Buzakov.App.Models.Films;

namespace Buzakov.App.Services
{

    public interface IFilmManager
    {

        List<Film> GetRandFilms( int limit = 5 );
        Film Details( string id );
        Film Create( IFilm film );
        void Delete( string id );

    }

}