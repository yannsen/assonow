using Projet2.Models;

namespace Projet2.ViewModels
{
    public class PaymentCreditCardViewModel
    {
        public PaymentViewModel PaymentViewModel { get; set; }

        public CreditCard NewCreditCard { get; set; }

        public CreditCard SavedCreditCard { get; set; }

        public bool SaveCard { get; set; }
    }
}
