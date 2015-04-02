using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buzakov.App.Models
{
    public interface IFilmLinkRelations
    {
        System.Collections.Generic.List<ILinkCommon> Links
        {
            get;
            set;
        }
    }
}
