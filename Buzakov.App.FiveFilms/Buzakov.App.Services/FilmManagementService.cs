using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

using AutoMapper;

using Buzakov.App.DataContext.EntityManager;
using Buzakov.App.Models.Films;
using Buzakov.App.Repositories;

namespace Buzakov.App.Services
{

    public class FilmManagementService : IFilmManager
    {

        private readonly IEntityManager _entityManager;
        private readonly FilmRepository _filmRepository;

        public FilmManagementService( IEntityManager entityManager, FilmRepository filmRepository )
        {
            _entityManager = entityManager;
            _filmRepository = filmRepository;
        }

        public Film Create( IFilm film )
        {
            if( film == null ) {
                throw new ArgumentNullException("film");
            }

            if( film.Title == null ) {
                throw new ArgumentNullException(film.Title);
            }

            if( film.Description == null ) {
                throw new ArgumentException(film.Description);
            }

            var entity = Mapper.Map<Film>(film);

            entity = _filmRepository.Insert(entity);
            _entityManager.Commit( );

            return entity;
        }

        public void Delete( IFilm film )
        {
            if( film == null ) {
                throw new ArgumentNullException("film");
            }

            if( film.Id == null ) {
                throw new ArgumentNullException("Id");
            }

            Film entity = _filmRepository.Find(film.Id);
            _filmRepository.Delete(entity);

            _entityManager.Commit( );
        }

        public List<Film> Search( string query )
        {
            if( query == null ) {
                throw new ArgumentNullException("query");
            }

            query = query.Trim( );
            if( query.Length <= 3 ) {
                throw new FormatException( );
            }

            IQueryable<Film> result = _filmRepository
                .AsQueryable( )
                .Where(a => a.Title.ToLower( ).Contains(query) || a.Description.ToLower( ).Contains(query));

            return result.ToList( );
        }

        public IFilm Details( string id )
        {
            if( id == null ) {
                throw new ArgumentNullException("id");
            }

            return _filmRepository.Find(id);
        }

        public List<IFilm> GetRandList( int limit = 5 )
        {
            string sql = "SELECT TOP " + limit + " Id FROM Films ORDER BY NEWID();";
            DbRawSqlQuery<string> query = _entityManager.GetContext( ).Database.SqlQuery<string>(sql);

            return query.Select(Details).ToList( );
        }

    }

}