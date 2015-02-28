using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.EntityFramework;

using Buzakov.App.DataContext.EntityManager;
using Buzakov.App.Repositories;

namespace Buzakov.App.Services
{

    public class RoleManagementService : IRoleManagementService
    {

        private readonly IEntityManager _entityManager;
        private readonly RoleRepository _roleRepository;

        public RoleManagementService( )
        {
            _entityManager = DependencyResolver.Current.GetService<IEntityManager>( );
            _roleRepository = _entityManager.GetRepository<RoleRepository>( );
        }

        public IEnumerable<IdentityRole> GetAll( )
        {
            return _roleRepository.AsQueryable( ).ToList( );
        }

        public IdentityRole Details( string id )
        {
            if( id == null ) {
                throw new ArgumentNullException("id");
            }

            var entity = _roleRepository.Find(id);
            if( entity == null ) {
                throw new ObjectNotFoundException( );
            }

            return entity;
        }

        public IdentityRole Create( string name )
        {
            if( name == null ) {
                throw new ArgumentNullException("name");
            }
            var entity = _roleRepository.Insert(new IdentityRole { Name = name });

            _entityManager.Commit( );

            return entity;
        }

        public void Delete( string id )
        {
            if( id == null ) {
                throw new ArgumentNullException("id");
            }

            var entity = _roleRepository.Find(id);
            if( entity == null ) {
                throw new ObjectNotFoundException( );
            }

            _roleRepository.Delete(entity);

            _entityManager.Commit( );
        }

    }

}