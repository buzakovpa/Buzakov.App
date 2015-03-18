﻿using System.Data.Entity;

using Buzakov.App.Models;
using Buzakov.App.Models.Films;

using Microsoft.AspNet.Identity.EntityFramework;

namespace Buzakov.App.DataContext
{

    public class ApplicationContext : IdentityDbContext<UserProfile>
    {

        public ApplicationContext( )
            : base("DefaultConnection")
        {
        }

        public IDbSet<DataLink> DataLinks { get; set; }
        public IDbSet<Film> Films { get; set; }

    }

}