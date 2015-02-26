namespace Buzakov.App.DataContext.Migrations.Seed
{

    public interface ISeed
    {

        void Execute(ApplicationContext context);

    }

}