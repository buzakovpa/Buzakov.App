using System.ComponentModel.DataAnnotations.Schema;

namespace Buzakov.App.Models
{

    [Table( "FilmDataLinkRelation" )]
    public class FilmDataLinkRelation : IFilmDataLinkRelation
    {

        public DataLink DataLink { get; set; }
        public Film Film { get; set; }
        public int Id { get; set; }

        IDataLink IFilmDataLinkRelation.DataLink
        {
            get
            {
                return DataLink;
            }
            set
            {
                DataLink = ( DataLink )value;
            }
        }

        IFilm IFilmDataLinkRelation.Film
        {
            get
            {
                return Film;
            }
            set
            {
                Film = ( Film )value;
            }
        }

    }

}