using Buzakov.App.Models;
using System;

namespace Buzakov.App.Mappers.Models
{
    public class LinkMapper : ILinkCommon
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }
    }
}