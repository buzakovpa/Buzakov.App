using Buzakov.App.DataContext;
using Buzakov.App.DataContext.EntityManager;
using Ninject.Modules;

namespace Buzakov.App.FiveFilms.App_Start
{

    public class CommonNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Kernel.Bind<ApplicationContext>().To<ApplicationContext>();
            Kernel.Bind<IEntityManager>().To<DefaultEntityManager>();
        }

    }

}