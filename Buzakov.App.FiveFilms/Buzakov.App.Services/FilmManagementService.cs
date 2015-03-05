using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

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

            IQueryable<Film> result = _filmRepository.AsQueryable( )
                .Where(a =>
                    a.Title.ToLower( ).Contains(query) ||
                    a.Description.ToLower( ).Contains(query));
            //.Select(Mapper.Map<Film>);

            return result.ToList( );
        }

        public List<Film> GetRandList( int limit = 5 )
        {
            string sql = "SELECT TOP " + limit + " Id FROM Films ORDER BY NEWID();";
            DbRawSqlQuery<int> query = _entityManager.GetContext( ).Database.SqlQuery<int>(sql);

            List<int> randIds = query.ToList( );
            var result = new List<Film>( );

            foreach( int id in randIds ) {
                result.Add(Details(id));
            }
            return result;
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

            if( film.DataLinkRelations == null || !film.DataLinkRelations.Any( ) ) {
                throw new ArgumentException(@"Links not found");
            }

            var entity = Mapper.Map<Film>(film);

            entity = _filmRepository.Insert(entity);
            _entityManager.Commit( );

            return entity;
        }

        public Film Update( IFilm film )
        {
            if( film == null ) {
                throw new ArgumentNullException("film");
            }

            if( film.Id <= 0 ) {
                throw new ArgumentNullException("Id");
            }

            if( film.Title == null ) {
                throw new ArgumentNullException(film.Title);
            }

            if( film.Description == null ) {
                throw new ArgumentException(film.Description);
            }

            if( film.DataLinkRelations == null || !film.DataLinkRelations.Any( ) ) {
                throw new ArgumentException(@"Links not found");
            }

            Film entity = _filmRepository.Find(film.Id);
            Mapper.Map(film, entity);
            entity = _filmRepository.Update(entity);

            _entityManager.Commit( );

            return entity;
        }

        public Film Details( int id )
        {
            if( id <= 0 ) {
                throw new ArgumentNullException("id");
            }

            return _filmRepository.Find(id);
        }

        public void Delete( IFilm film )
        {
            if( film == null ) {
                throw new ArgumentNullException("film");
            }

            if( film.Id <= 0 ) {
                throw new ArgumentNullException("Id");
            }

            Film entity = _filmRepository.Find(film.Id);
            _filmRepository.Delete(entity);

            _entityManager.Commit( );
        }

    }

}