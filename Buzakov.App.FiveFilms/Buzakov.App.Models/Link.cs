using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buzakov.App.Models
{
    public class Link : ILinkCommon, ISoftDelete
    {
        public Guid Id { get; set; }

        public string Url { get; set; }
        public string Title { get; set; }

        public bool IsDeleted { get; set; }
    }
}