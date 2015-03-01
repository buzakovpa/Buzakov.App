namespace Buzakov.App.Models
{
    public interface IDataLink : ILink
    {
        string Title { get; set; }
        string Description { get; set; }
    }
}