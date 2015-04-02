using Buzakov.App.DataContext;
using Buzakov.App.DataContext.Repositories;
using Ninject;
using Ninject.Modules;

namespace Buzakov.App.FiveFilms.App_Start
{
    public class MainNinjectModule : NinjectModule
    {
        public override void Load( )
        {
            IKernel kr = Kernel;

            kr.Bind<ApplicationContext>( ).To<ApplicationContext>( );
            kr.Bind<IEntityManager>( ).To<DefaultEntityManager>( );
            kr.Bind<IFilmRepository>( ).To<DefaultFilmRepository>( );
            kr.Bind<ILinkRepository>( ).To<DefaultLinkRepository>( );
        }
    }
}