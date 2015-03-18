using System;
using System.Linq.Expressions;

namespace Buzakov.App.DataContext.EntityManager
{

    public interface IEntityManager : IDisposable
    {

        ApplicationContext GetContext();

        void Commit();

    }

}