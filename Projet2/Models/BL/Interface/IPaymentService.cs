using Projet2.ViewModels;

namespace Projet2.Models.BL.Interface
{
    public interface IPaymentService
    {
        public int CreatePayment(PaymentViewModel paymentViewModel);
    }
}
