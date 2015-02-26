using System.Web;
using System.Web.Mvc;

namespace Buzakov.App.FiveFilms
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute( ));
        }
    }
}
