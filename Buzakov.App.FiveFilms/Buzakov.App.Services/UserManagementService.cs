using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

using Buzakov.App.DataContext;
using Buzakov.App.Repositories;
using Buzakov.App.DataContext.EntityManager;

namespace Buzakov.App.Services
{

    public class UserManagementService : IUserManagementService
    {

        private readonly IEntityManager _entityManager;
        private readonly UserProfileRepository _userProfileRepository;

        public UserManagementService(IEntityManager entityManager)
        {
            _entityManager = entityManager;
            _userProfileRepository = entityManager.GetRepository<UserProfileRepository>( );
        }

        public IEnumerable<UserProfile> GetAll( )
        {
            return _userProfileRepository.AsQueryable( ).ToList( );
        }

        public UserProfile Get(string id)
        {
            return _userProfileRepository.Find(id);
        }

        public UserProfile AssineRole(string userId, IdentityRole role)
        {
            var entity = _userProfileRepository.Find(userId);
            entity.Roles.Add(new IdentityUserRole {
                RoleId = role.Id,
                UserId = userId
            });

            _entityManager.Commit( );

            return entity;
        }

        public void Delete(string id)
        {
            var entity = _userProfileRepository.Find(id);
            _userProfileRepository.Delete(entity);

            _entityManager.Commit( );
        }

    }

}