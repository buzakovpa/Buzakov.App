﻿using Ninject.Modules;

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

            Kernel.Bind<IUserManager>().To<UserManagementService>();
            Kernel.Bind<IRoleManager>().To<RoleManagementService>();
            Kernel.Bind<IDataLinkManager>( ).To<DataLinkManagementService>( );
            Kernel.Bind<IFilmManager>().To<FilmManagementService>();
        }

    }

}