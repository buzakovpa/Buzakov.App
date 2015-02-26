using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Buzakov.App.DataContext.EntityManager
{

    public interface IEntityManager : IDisposable
    {

        ApplicationContext GetContext();
        TRepository GetRepository<TRepository>() where TRepository : IRepository, new();
        void Commit();

    }

    public class DefaultEntityManager : IEntityManager
    {

        private ApplicationContext _context;
        private List<IRepository> _repositories;

        public DefaultEntityManager(ApplicationContext context)
        {
            _context = context;
            _repositories = new List<IRepository>();
        }

        public ApplicationContext GetContext()
        {
            return _context;
        }

        public TRepository GetRepository<TRepository>() where TRepository : IRepository, new()
        {
            if (!_repositories.Any(a => a is TRepository))
            {
                var newRepository = new TRepository();
                _repositories.Add(newRepository);
            }

            return _repositories.OfType<TRepository>().First(a => a is TRepository);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

    }

}