using Buzakov.App.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Buzakov.App.DataContext.Configurations
{
    class LinkConfiguration : EntityTypeConfiguration<Link>
    {
        public LinkConfiguration( )
        {
            HasKey<Guid>( a => a.Id );
            Property( a => a.Id ).HasDatabaseGeneratedOption( DatabaseGeneratedOption.Identity );
        }
    }
}
