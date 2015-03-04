namespace Buzakov.App.Models
{

    public interface IFilmDataLinkRelation
    {

        int Id { get; set; }

        IDataLink DataLink { get; set; }
        IFilm Film { get; set; }

    }

}