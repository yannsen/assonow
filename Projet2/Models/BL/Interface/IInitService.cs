namespace Projet2.Models.BL.Interface
{
    public interface IInitService
    {
        public void DeleteCreateDatabase();

        public void InitializeDB();

        public void Dispose();
    }
}