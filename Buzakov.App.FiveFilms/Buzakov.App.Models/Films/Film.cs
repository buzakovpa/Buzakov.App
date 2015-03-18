using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Buzakov.App.Models.Films
{

    [Table( "Films" )]
    public class Film : IFilm, ISoftDelete
    {

        public virtual List<DataLink> Links { get; set; }

        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int View { get; set; }

        List<IDataLink> IFilmLinks.Links
        {
            get { return Links.OfType<IDataLink>( ).ToList( ); }
            set { Links = value.OfType<DataLink>( ).ToList( ); }
        }

        public bool IsDeleted { get; set; }

    }

}