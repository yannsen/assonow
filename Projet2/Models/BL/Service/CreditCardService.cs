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
            CreditCard formerCard = new CreditCard();
            formerCard = _bddContext.CreditCard.FirstOrDefault(c => c.MemberId == creditCard.MemberId);
            if(formerCard == null)
                _bddContext.Add(creditCard);
            else
            {
                formerCard = new CreditCard 
                { 
                    CardNumber = creditCard.CardNumber,
                    Cvc = creditCard.Cvc, 
                    DateTime = creditCard.DateTime, 
                    Firstname = creditCard.Firstname,
                    Lastname = creditCard.Lastname,
                    MemberId = creditCard.MemberId,
                };
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
