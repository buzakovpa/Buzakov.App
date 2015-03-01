using AutoMapper;

using Buzakov.App.FiveFilms.Areas.Api.Models;
using Buzakov.App.Models;

namespace Buzakov.App.FiveFilms.Infrastructure.Mappers
{

    public class DataLinkMapper : IMapper
    {

        public void Config( )
        {
            Mapper.CreateMap<DataLink, DataLinkBindingModel>( );
            Mapper.CreateMap<DataLinkBindingModel, DataLink>( );
        }

    }

}