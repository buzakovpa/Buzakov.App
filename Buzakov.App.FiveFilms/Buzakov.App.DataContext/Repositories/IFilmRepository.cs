using Buzakov.App.Models;
using System.Collections.Generic;
using System.Linq;

namespace Buzakov.App.DataContext.Repositories
{
    public interface IFilmRepository
    {
        Film Find(object id);
        TMap FindMapped<TMap>(object id) where TMap : IFilmCommon;

        Film Create( Film film );

        IQueryable<Film> SearchQueryable( string query, int limit = 20 );
        List<TMap> SearchMapped<TMap>( string query, int limit = 20 ) where TMap : IFilmCommon;

        IQueryable<Film> RandQueryable(int limit = 5);
        List<TMap> RandMapped<TMap>(int limit = 5) where TMap : IFilmCommon;
    }
}