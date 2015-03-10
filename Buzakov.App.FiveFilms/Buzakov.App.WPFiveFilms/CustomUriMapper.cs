using System;
using System.Net;
using System.Windows.Navigation;

namespace Buzakov.App.WPFiveFilms
{

    public class CustomUriMapper : UriMapperBase
    {

        public override Uri MapUri( Uri uri )
        {
            var uriToLaunch = HttpUtility.UrlDecode(uri.ToString( ));

            if( uriToLaunch.Contains("buzakov-5films:Show") ) {
                uri = new Uri("/MainPage.xaml", UriKind.Relative);
            }

            return uri;
        }

    }

}