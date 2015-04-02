using AutoMapper;
using Buzakov.App.Mappers.Models;
using Buzakov.App.Models;

namespace Buzakov.App.Mappers.Configurations
{
    public class FilmConfiguration :IMapperConfiguration
    {
        public void Init( )
        {
            Mapper.CreateMap<Film, FilmMapper>( );
            Mapper.CreateMap<FilmMapper, Film>( );
        }
    }
}