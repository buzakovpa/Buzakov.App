using Buzakov.App.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Buzakov.App.FiveFilms.Areas.Api.Models
{
    public class FilmMapped : IFilmCommon, IFilmLinkRelations
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public LinkMapped MainScreen { get; set; }
        ILinkCommon IFilmCommon.MainScreen
        {
            get { return (ILinkCommon)MainScreen; }
            set { MainScreen = (LinkMapped)value; }
        }

        public List<LinkMapped> Links { get; set; }
        List<ILinkCommon> IFilmLinkRelations.Links
        {
            get { return Links.OfType<ILinkCommon>( ).ToList( ); }
            set { Links = value.OfType<LinkMapped>( ).ToList( ); }
        }

    }
}