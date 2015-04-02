using Buzakov.App.Models;
using System;

namespace Buzakov.App.FiveFilms.Areas.Api.Models
{
    public class LinkMapped : ILinkCommon
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }
    }
}