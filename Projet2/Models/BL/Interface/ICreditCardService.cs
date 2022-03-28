namespace Projet2.Models.BL.Interface
{
    public interface ICreditCardService
    {
        public int SaveCard(CreditCard creditCard);

        public CreditCard GetSavedCard(int memberId);
    }
}
