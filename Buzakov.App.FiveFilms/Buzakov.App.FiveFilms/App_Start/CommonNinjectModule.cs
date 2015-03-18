using Buzakov.App.DataContext;
using Buzakov.App.DataContext.EntityManager;
using Buzakov.App.Models;
using Buzakov.App.Repositories;
using Buzakov.App.Services;

using Ninject;
using Ninject.Modules;

namespace Buzakov.App.FiveFilms.App_Start
{

    public class CommonNinjectModule : NinjectModule
    {

        public override void Load( )
        {
            IKernel kr = Kernel;

            kr.Bind<ApplicationContext>( ).To<ApplicationContext>( );
            kr.Bind<IEntityManager>( ).To<EntityManager>( );

            kr.Bind<DataLinkRepository>( ).ToSelf( );
            kr.Bind<FilmRepository>( ).ToSelf( );
            kr.Bind<RoleRepository>( ).ToSelf( );
            kr.Bind<UserProfileRepository>( ).ToSelf( );

            kr.Bind<IUserManager>( ).To<UserManagementService>( );
            kr.Bind<IRoleManager>( ).To<RoleManagementService>( );
            kr.Bind<IDataLinkManager>( ).To<DataLinkManagementService>( );
            kr.Bind<IFilmManager>( ).To<FilmManagementService>( );
        }

    }

}