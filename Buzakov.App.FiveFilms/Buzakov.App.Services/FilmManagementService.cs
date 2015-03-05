using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using AutoMapper;

using Buzakov.App.DataContext.EntityManager;
using Buzakov.App.Models;
using Buzakov.App.Repositories;

namespace Buzakov.App.Services
{

    public class FilmManagementService : IFilmManager
    {

        private readonly IEntityManager _entityManager;
        private readonly FilmRepository _filmRepository;

        public FilmManagementService( IEntityManager entityManager )
        {
            _entityManager = entityManager;
            _filmRepository = _entityManager.GetRepository<FilmRepository>( );
        }

        public List<Film> Search( string query )
        {
            if( query == null ) {
                throw new ArgumentNullException("query");
            }

            if( query.Trim( ).Length <= 3 ) {
                throw new FormatException( );
            }

            var result = _filmRepository.AsQueryable( )
                .Where(a =>
                    a.Title.ToLower( ).Contains(query) ||
                    a.Description.ToLower( ).Contains(query));
                //.Select(Mapper.Map<Film>);

            return result.ToList( );
        }

        public List<Film> GetRandList( int limit = 5)
        {
            var sql = "SELECT TOP " + limit + " Id FROM Films ORDER BY NEWID();";
            var query = _entityManager.GetContext( ).Database.SqlQuery<int>(sql);

            var randIds = query.ToList( );
            var result = new List<Film>( );

            foreach( int id in randIds ) {
                result.Add(Details(id));
            }
            return result;
        }

        public Film Create( IFilm film )
        {
        }

        public Film Update( IFilm film )
        {
        }

        public Film Details( int id )
        {
        }

        public void Delete( IFilm film )
        {
        }

    }

}