using Buzakov.App.Models;

namespace Buzakov.App.FiveFilms.Areas.Api.Models
{

    public class DataLinkBindingModel : IDataLink
    {

        public int Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

    }

}
