using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Buzakov.App.Models
{

    [Table( "Films" )]
    public class Film : IFilm, ISoftDelete
    {

        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public List<FilmDataLinkRelation> DataLinkRelations { get; set; }

        List<IFilmDataLinkRelation> IFilmDescription.DataLinkRelations
        {
            get
            {
                return DataLinkRelations.OfType<IFilmDataLinkRelation>( ).ToList( );
            }
            set
            {
                DataLinkRelations = value.OfType<FilmDataLinkRelation>( ).ToList( );
            }
        }

        public bool IsDeleted { get; set; }

    }

}