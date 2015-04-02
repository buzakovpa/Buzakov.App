using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buzakov.App.Models
{
    public interface ILinkCommon
    {
        Guid Id
        {
            get;
            set;
        }

        string Url
        {
            get;
            set;
        }

        string Title
        {
            get;
            set;
        }
    }
}
