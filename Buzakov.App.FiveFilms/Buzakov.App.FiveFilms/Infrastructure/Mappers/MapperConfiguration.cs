using System;
using System.Linq;

namespace Buzakov.App.FiveFilms.Infrastructure.Mappers
{

    public static class MapperConfiguration
    {

        public static void Init( )
        {
            var type = typeof( IMapper );
            var types = AppDomain.CurrentDomain.GetAssemblies( ).SelectMany(s => s.GetTypes( )).Where(type.IsAssignableFrom);

            foreach( Type item in types ) {
                if( item.IsClass ) {
                    var obj = ( IMapper )Activator.CreateInstance(item);
                    obj.Config( );
                }
            }
        }

    }

}