using Ninject.Modules;

using Buzakov.App.DataContext;
using Buzakov.App.DataContext.EntityManager;
using Buzakov.App.Services;

namespace Buzakov.App.FiveFilms.App_Start
{

    public class CommonNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Kernel.Bind<ApplicationContext>().To<ApplicationContext>();
            Kernel.Bind<IEntityManager>().To<EntityManager>();

            Kernel.Bind<IUserManagementService>().To<UserManagementService>();
            Kernel.Bind<IRoleManagementService>().To<RoleManagementService>();
        }

    }

}