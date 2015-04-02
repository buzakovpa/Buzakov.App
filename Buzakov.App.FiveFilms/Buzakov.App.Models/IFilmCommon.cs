using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buzakov.App.Models
{
    public interface IFilmCommon
    {
        Guid Id { get; set; }

        string Title { get; set; }
        string Description { get; set; }

        ILinkCommon MainScreen { get; set; }
    }
}