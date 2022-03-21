namespace Projet2.Models.BL.Interface
{
    public interface IAuthentificationService
    {
        public Member Authenticate(string pseudonym, string password);

        public Member GetMember(int id);

        public Member GetMember(string idStr);

        public string EncodeMD5(string motDePasse);
    }
}
