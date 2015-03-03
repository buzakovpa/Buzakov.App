namespace Buzakov.App.Models
{

    public interface ILinkDescription
    {

        string Title { get; set; }
        string Description { get; set; }
        LinkType Type { get; set; }

    }

}