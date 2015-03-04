using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buzakov.App.Models
{

    [Table( "Films" )]
    public class Film : IFilm, IFilmDescription, ISoftDelete
    {

        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public List<IFilmDataLinkRelation> DataLinkRelations { get; set; }

        public bool IsDeleted { get; set; }

    }

}