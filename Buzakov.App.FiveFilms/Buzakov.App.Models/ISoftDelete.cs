﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buzakov.App.Models
{
    public interface ISoftDelete
    {
        bool IsDeleted
        {
            get;
            set;
        }
    }
}
