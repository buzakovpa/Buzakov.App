using Buzakov.App.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Buzakov.App.DataContext.Configurations
{
    class FilmConfiguration : EntityTypeConfiguration<Film>
    {
        public FilmConfiguration( )
        {
            HasKey<Guid>( a => a.Id );
            Property( a => a.Id ).HasDatabaseGeneratedOption( databaseGeneratedOption: DatabaseGeneratedOption.Identity );
        }
    }
}