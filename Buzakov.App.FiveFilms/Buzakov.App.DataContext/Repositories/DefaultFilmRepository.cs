using Buzakov.App.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using AutoMapper;

namespace Buzakov.App.DataContext.Repositories
{
    public class DefaultFilmRepository : BaseRepository<Film>, IFilmRepository
    {
        public DefaultFilmRepository( ApplicationContext context )
            : base( context )
        {
        }

        public Film Find(object id)
        {
            if (id == null) { throw new ArgumentNullException("id"); }

            return base.Find(id);
        }

        public TMap FindMapped<TMap>(object id)
            where TMap : IFilmCommon
        {
            if (id == null) { throw new ArgumentNullException("id"); }

            var entity = base.Find(id);

            return Mapper.Map<TMap>(entity);
        }

        public Film Create( Film film )
        {
            if( film == null ) { throw new ArgumentNullException( "film" ); }
            if( film.Title == null ) { throw new ArgumentNullException("Id"); }
            if( film.MainScreen == null ) { throw new ArgumentNullException( "MainScreen" ); }

            return Insert(film);
        }

        public IQueryable<Film> SearchQueryable(string query, int limit = 20)
        {
            if (query == null) { throw new ArgumentNullException("query"); }

            query = query.ToLowerInvariant( );

            return AsQueryable( )
                .Where(a =>
                    a.Title.ToLower( ).Contains(query) ||
                    a.Description.ToLower( ).Contains(query))
                .Take(limit);
        }

        public List<TMap> SearchMapped<TMap>(string query, int limit = 20)
            where TMap : IFilmCommon
        {
            var entityList = SearchQueryable(query, limit).ToList();

            return Mapper.Map<List<TMap>>(entityList);
        }

        public IQueryable<Film> RandQueryable(int limit = 5)
        {
            return AsQueryable( )
                .OrderBy(a => Guid.NewGuid( ))
                .Take(limit);
        }

        public List<TMap> RandMapped<TMap>(int limit = 5) 
            where TMap : IFilmCommon
        {
            var entityList = RandQueryable(limit).ToList( );

            return Mapper.Map<List<TMap>>(entityList);
        }
    }
}
