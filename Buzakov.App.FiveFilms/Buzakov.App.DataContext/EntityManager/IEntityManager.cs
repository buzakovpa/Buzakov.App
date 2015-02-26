using System;
using System.Linq.Expressions;

namespace Buzakov.App.DataContext.EntityManager
{

    public interface IEntityManager : IDisposable
    {

        ApplicationContext GetContext();
        TRepository GetRepository<TRepository>() where TRepository : IRepository, new();
        void Commit();

    }

}