using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Buzakov.App.FiveFilms.Infrastructure.Helpers
{

    public static class DisplayModeHelper
    {

        public static bool IsWindowsPhone( this Controller controller )
        {
            var currentMode = _getDisplayMode(controller);

            return currentMode == DisplayModes.WP;
        }

        public static bool IsIphone( this Controller controller )
        {
            var currentMode = _getDisplayMode(controller);

            return currentMode == DisplayModes.Iphone;
        }

        public static bool IsAndroid( this Controller controller )
        {
            var currentMode = _getDisplayMode(controller);

            return currentMode == DisplayModes.Android;
        }

        private static string _getDisplayMode( Controller controller )
        {
            var modes = DisplayModeProvider.Instance.Modes;
            var length = modes.Count;

            for( int i = 0; i < length; i++ ) {
                if( modes[ i ].CanHandleContext(controller.HttpContext) ) {
                    return modes[ i ].DisplayModeId;
                }
            }

            return DisplayModes.Desktop;
        }

    }

}