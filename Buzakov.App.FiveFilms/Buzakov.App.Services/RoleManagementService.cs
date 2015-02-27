using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public IdentityRole Get(string id)
        {
            return _roleRepository.Find(id);
        }

        public void Delete(string id)
        {
            var entity = _roleRepository.Find(id);
            _roleRepository.Delete(entity);

            _entityManager.Commit( );
        }

    }

}