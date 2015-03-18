using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;

using AutoMapper;

using Buzakov.App.DataContext.EntityManager;
using Buzakov.App.Models;
using Buzakov.App.Repositories;

namespace Buzakov.App.Services
{

    public class DataLinkManagementService : IDataLinkManager
    {

        private readonly DataLinkRepository _dataLinkRepository;
        private readonly IEntityManager _entityManager;

        public DataLinkManagementService( IEntityManager entityManager, DataLinkRepository dataLinkRepository )
        {
            _entityManager = entityManager;
            _dataLinkRepository = dataLinkRepository;
        }

        public IEnumerable<DataLink> GetAll( )
        {
            return _dataLinkRepository.AsQueryable( ).ToList( );
        }

        public DataLink Details( int id )
        {
            var entity = _dataLinkRepository.Find(id);
            if( entity == null ) {
                throw new ObjectNotFoundException( );
            }

            return entity;
        }

        public DataLink Create( IDataLink link )
        {
            if( link == null ) {
                throw new ArgumentNullException("link");
            }

            if( link.Url == null ) {
                throw new ArgumentNullException(link.Url);
            }

            var tmpItem = Mapper.Map<DataLink>(link);
            var entity = _dataLinkRepository.Insert(tmpItem);

            _entityManager.Commit( );
            return entity;
        }

        public DataLink Update( IDataLink link )
        {
            if( link == null ) {
                throw new ArgumentNullException("link");
            }

            if( link.Url == null ) {
                throw new ArgumentNullException(link.Url);
            }

            var tmpItem = Mapper.Map<DataLink>(link);
            var entity = _dataLinkRepository.Find(link.Id);
            if( entity == null ) {
                throw new ObjectNotFoundException( );
            }

            entity = _dataLinkRepository.Update(tmpItem);

            _entityManager.Commit( );
            return entity;
        }

        public void Delete( int id )
        {
            var entity = _dataLinkRepository.Find(id);
            if( entity == null ) {
                throw new ObjectNotFoundException( );
            }

            _dataLinkRepository.Delete(entity);

            _entityManager.Commit( );
        }

    }

}