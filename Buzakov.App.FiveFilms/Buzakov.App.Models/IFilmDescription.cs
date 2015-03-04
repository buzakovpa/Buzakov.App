using System.Collections.Generic;

namespace Buzakov.App.Models
{

    public interface IFilmDescription
    {

        string Title { get; set; }
        string Description { get; set; }

        List<IFilmDataLinkRelation> DataLinkRelations { get; set; }

    }

}