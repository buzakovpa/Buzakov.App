using Buzakov.App.Models;

namespace Buzakov.App.DataContext.Repositories
{
    public interface ILinkRepository
    {
        Link Create( Link link );
    }
}