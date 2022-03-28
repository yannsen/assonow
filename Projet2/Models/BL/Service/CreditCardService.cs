using Projet2.Models.BL.Interface;
using System;
using System.Linq;
using System.Security.Claims;

namespace Projet2.Models.BL.Service
{
    public class CreditCardService : ICreditCardService
    {
        private BddContext _bddContext;

        public CreditCardService()
        {
            _bddContext = new BddContext();
        }

        public int SaveCard(CreditCard creditCard)
        {
            if(!_bddContext.CreditCard.Any(c => c.MemberId == creditCard.MemberId))
                _bddContext.Add(creditCard);
            else
            {
                CreditCard formerCard = GetSavedCard(creditCard.MemberId);
                formerCard.CardNumber = creditCard.CardNumber;
                formerCard.Cvc = creditCard.Cvc;
                formerCard.DateTime = creditCard.DateTime;
                formerCard.Firstname = creditCard.Firstname;
                formerCard.Lastname = creditCard.Lastname;
                _bddContext.Update(formerCard);
            }
            _bddContext.SaveChanges();
            return creditCard.Id;
        }

        public CreditCard GetSavedCard(int memberId)
        {
            return _bddContext.CreditCard.FirstOrDefault(c => c.MemberId == memberId);
        }
    }
}
