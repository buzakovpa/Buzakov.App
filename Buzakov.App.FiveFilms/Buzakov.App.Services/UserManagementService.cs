using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Identity.EntityFramework;

using Buzakov.App.DataContext;
using Buzakov.App.Repositories;
using Buzakov.App.DataContext.EntityManager;

namespace Buzakov.App.Services
{

    public class UserManagementService : IUserManager
    {

        private readonly IEntityManager _entityManager;
        private readonly UserProfileRepository _userProfileRepository;
        private readonly IRoleManager _roleManager;

        public UserManagementService( IEntityManager entityManager, UserProfileRepository userProfileRepository, IRoleManager roleManager )
        {
            _entityManager = entityManager;
            _userProfileRepository = userProfileRepository;
            _roleManager = roleManager;
        }

        public IEnumerable<UserProfile> GetAll( )
        {
            return _userProfileRepository.AsQueryable( ).ToList( );
        }

        public UserProfile Details( string id )
        {
            if( id == null ) {
                throw new ArgumentNullException("id");
            }

            var entity = _userProfileRepository.Find(id);
            if( entity == null ) {
                throw new ObjectNotFoundException( );
            }

            return entity;
        }

        public UserProfile AssineRole( string userId, string roleId )
        {
            if( userId == null ) {
                throw new ArgumentNullException("userId");
            }

            if( roleId == null ) {
                throw new ArgumentNullException("roleId");
            }

            var role = _roleManager.Details(roleId);
            if( role == null ) {
                throw new ObjectNotFoundException( );
            }

            var entity = _userProfileRepository.Find(userId);
            if( entity == null ) {
                throw new ObjectNotFoundException( );
            }

            entity.Roles.Add(new IdentityUserRole {
                RoleId = role.Id,
                UserId = userId
            });

            _entityManager.Commit( );

            return entity;
        }

        public void Delete( string id )
        {
            if( id == null ) {
                throw new ArgumentNullException("id");
            }

            var entity = _userProfileRepository.Find(id);
            if( entity == null ) {
                throw new ObjectNotFoundException( );
            }

            _userProfileRepository.Delete(entity);

            _entityManager.Commit( );
        }
    }
}