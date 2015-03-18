using System.Collections.Generic;

namespace Buzakov.App.Models.Films
{

    public interface IFilmLinks
    {

        List<IDataLink> Links { get; set; }

    }

}