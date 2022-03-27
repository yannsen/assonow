using Projet2.Models.BL.Interface;
using Projet2.ViewModels;
using System;

namespace Projet2.Models.BL.Service
{
    public class PaymentService : IPaymentService
    {
        private BddContext _bddContext;

        public PaymentService()
        {
            _bddContext = new BddContext();
        }

        public int CreatePayment(PaymentViewModel paymentViewModel)
        {
            Payment payment;
            if (paymentViewModel.DonationId != null)
            {
                payment = new Payment { DonationId = paymentViewModel.DonationId, Amount = Int32.Parse(paymentViewModel.Amount), Date = DateTime.Today };
            }
            else if (paymentViewModel.ContributionId != null)
            {
                payment = new Payment { DonationId = paymentViewModel.ContributionId, Amount = Int32.Parse(paymentViewModel.Amount), Date = DateTime.Today };
            }
            else
            {
                payment = new Payment { DonationId = paymentViewModel.CommandId, Amount = Int32.Parse(paymentViewModel.Amount), Date = DateTime.Today };
            }
            _bddContext.Payment.Add(payment);
            _bddContext.SaveChanges();
            return payment.Id;
        }
    }
}
