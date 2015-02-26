namespace Buzakov.App.Models
{

    public interface ISoftDelete
    {

        bool IsDeleted { get; set; }

    }

}