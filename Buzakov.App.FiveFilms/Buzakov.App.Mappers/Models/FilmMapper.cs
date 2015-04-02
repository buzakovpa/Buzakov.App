using Buzakov.App.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Buzakov.App.Mappers.Models
{
    public class FilmMapper : IFilmCommon, IFilmLinkRelations
    {
        
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public LinkMapper MainScreen { get; set; }

        public List<LinkMapper> Links { get; set; }

        ILinkCommon IFilmCommon.MainScreen
        {
            get { return MainScreen; }
            set { MainScreen = (LinkMapper)value; }
        }

        List<ILinkCommon> IFilmLinkRelations.Links
        {
            get { return Links.OfType<ILinkCommon>( ).ToList( ); }
            set { Links = value.OfType<LinkMapper>( ).ToList( ); }
        }
    }
}