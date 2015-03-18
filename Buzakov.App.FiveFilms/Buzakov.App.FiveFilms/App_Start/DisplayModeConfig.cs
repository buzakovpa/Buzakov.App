using System.Web.WebPages;

using Buzakov.App.FiveFilms.Infrastructure.Helpers;

namespace Buzakov.App.FiveFilms.App_Start
{

    public static class DisplayModeConfig
    {

        public static void Init( )
        {
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode(DisplayModes.WP) {
                    ContextCondition = (
                        context => context.GetOverriddenUserAgent( ).Contains("Windows Phone") ||
                                   context.GetOverriddenUserAgent( ).Contains("WPDesktop") ),
                });
        }

    }

}