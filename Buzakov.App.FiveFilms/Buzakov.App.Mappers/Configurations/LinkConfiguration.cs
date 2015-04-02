using AutoMapper;
using Buzakov.App.Mappers.Models;
using Buzakov.App.Models;

namespace Buzakov.App.Mappers.Configurations
{
    public class LinkConfiguration :IMapperConfiguration
    {
        public void Init( )
        {
            Mapper.CreateMap<Link, LinkMapper>( );
            Mapper.CreateMap<LinkMapper, Link>( );
        }
    }
}