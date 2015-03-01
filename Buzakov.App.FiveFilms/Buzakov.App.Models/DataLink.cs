using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buzakov.App.Models
{

    [Table( "DataLinks" )]
    public class DataLink : IDataLink
    {

        [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }

        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

    }

}