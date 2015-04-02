using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Buzakov.App.Mappers
{
    public static class MapperConfiguration
    {
        public static void Init( )
        {
            var types = System.Reflection.Assembly.GetExecutingAssembly( ).GetTypes( ).Where(mytype => mytype.GetInterfaces( ).Contains(typeof(IMapperConfiguration)));

            foreach (var item in types) {
                var instance = (IMapperConfiguration)Activator.CreateInstance(item);
                instance.Init( );
            }
        }
    }
}