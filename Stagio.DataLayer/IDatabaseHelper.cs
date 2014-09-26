namespace Stagio.DataLayer
{
    public interface IDatabaseHelper
    {
        void DropCreateDatabaseIfModelChanges();

        void DeleteAll();


    }
}