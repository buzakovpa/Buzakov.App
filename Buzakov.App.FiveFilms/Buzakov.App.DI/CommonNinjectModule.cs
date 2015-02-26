using Buzakov.App.DataContext;
using Buzakov.App.DataContext.EntityManager;
using Ninject.Modules;

namespace Buzakov.App.DI
{

    public class CommonNinjectModule : NinjectModule
    {

        public override void Load()
        {
            var kernel = Kernel;

            kernel.Bind<IEntityManager>().To<DefaultEntityManager>();
        }

    }

}