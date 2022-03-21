using Projet2.Models.BL.Interface;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Projet2.Models.BL.Service
{
    public class AuthentificationService : IAuthentificationService
    {
        private BddContext _bddContext;
        public AuthentificationService()
        {
            _bddContext = new BddContext();
        }

        public Member Authenticate(string pseudonym, string password)
        {
            string motDePasse = EncodeMD5(password);
            Member member = this._bddContext.Member.FirstOrDefault(m => m.Pseudonym == pseudonym && m.Password == motDePasse);
            return member;
        }

        public Member GetMember(int id)
        {
            return this._bddContext.Member.FirstOrDefault(m => m.Id == id);
        }

        public Member GetMember(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetMember(id);
            }
            return null;
        }

        public string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "AssoNow" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
    }
}
