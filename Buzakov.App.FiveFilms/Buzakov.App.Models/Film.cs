using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buzakov.App.Models
{
    public class Film : IFilmCommon, IFilmLinkRelations, ISoftDelete
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Link MainScreen { get; set; }
        ILinkCommon IFilmCommon.MainScreen
        {
            get { return ( ILinkCommon )MainScreen; }
            set { MainScreen = ( Link )value; }
        }

        public bool IsDeleted { get; set; }

        public virtual List<Link> Links { get; set; }
        List<ILinkCommon> IFilmLinkRelations.Links
        {
            get { return Links.OfType<ILinkCommon>( ).ToList( ); }
            set { Links = value.OfType<Link>( ).ToList( ); }
        }

    }
}