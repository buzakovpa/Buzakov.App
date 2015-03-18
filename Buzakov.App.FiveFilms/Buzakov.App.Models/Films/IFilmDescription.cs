namespace Buzakov.App.Models.Films
{

    public interface IFilmDescription
    {

        string Title { get; set; }
        string Description { get; set; }

        int View { get; set; }

    }

}