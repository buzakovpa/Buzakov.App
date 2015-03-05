using System.Collections.Generic;

using Buzakov.App.Models;

namespace Buzakov.App.Services
{

    public interface IFilmManager
    {

        List<Film> Search( string query );
        List<Film> GetRandList( int limit );

        Film Create( IFilm film );
        Film Update( IFilm film );
        Film Details( int id );

        void Delete( IFilm film );

    }

}