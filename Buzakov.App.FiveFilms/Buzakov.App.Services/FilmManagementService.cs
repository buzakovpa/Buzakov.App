using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;

using AutoMapper;

using Buzakov.App.DataContext.EntityManager;
using Buzakov.App.Models;
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

        public List<Film> GetRandFilms( int limit = 5 )
        {
            var sql = "SELECT TOP " + limit + " Id FROM Films ORDER BY NEWID();";
            var query = _entityManager.GetContext( ).Database.SqlQuery<string>(sql);

            return query.Select(Details).ToList( );
        }

        public Film Details( string id )
        {
            if( id == null ) {
                throw new ArgumentNullException("id");
            }

            return _filmRepository.Find(id);
        }

        public Film Create( IFilm film )
        {
            if( film == null ) {
                throw new ArgumentNullException("film");
            }

            if( film.Title == null ) {
                throw new ArgumentNullException("film.Title");
            }

            var entity = new Film {
                Title = film.Title,
                Description = film.Description,
                Links = new List<DataLink>( ),
            };

            if( film.Links != null ) {
                foreach( var item in film.Links ) {
                    entity.Links.Add(new DataLink {
                        Title = item.Title,
                        Description = item.Description,
                        Type = item.Type,
                        Url = item.Url,
                    });
                }
            }

            _entityManager.Commit( );

            return entity;
        }

        public void Delete( string id )
        {
            if( id == null ) {
                throw new ArgumentNullException("id");
            }

            var entity = _filmRepository.Find(id);
            if( entity == null ) {
                throw new ObjectNotFoundException("The film is not found");
            }
            
            _filmRepository.Delete(entity);
        }

    }

}