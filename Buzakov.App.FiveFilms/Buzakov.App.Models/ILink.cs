namespace Buzakov.App.Models
{
    public interface ILink : ISoftDelete
    {
        int Id { get; set; }
        string Url { get; set; }
    }
}