using Microsoft.AspNetCore.Mvc;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;
using Projet2.Models;
using System;
using System.Security.Claims;

namespace Projet2.Controllers
{
    public class PaymentController : Controller
    {
        private IPaymentService paymentService;
        private ICreditCardService creditCardService;
        private BddContext _bddContext;

        public PaymentController()
        {
            this.paymentService = new PaymentService();
            this.creditCardService = new CreditCardService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreditCard (PaymentViewModel paymentViewModel)
        {
            PaymentCreditCardViewModel viewModel = new PaymentCreditCardViewModel();
            viewModel.SavedCreditCard = creditCardService.GetSavedCard(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            viewModel.PaymentViewModel = paymentViewModel;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreditCard(PaymentCreditCardViewModel viewModel)
        {
            if(viewModel.SaveCard == true)
            {
                viewModel.NewCreditCard.MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                creditCardService.SaveCard(viewModel.NewCreditCard);
            }
            return RedirectToAction("Validation", "Payment", viewModel.PaymentViewModel);
        }

        public IActionResult Validation(PaymentViewModel viewModel)
        {
            if (viewModel.DonationId != null)
            {
                ViewBag.Next = "../Donation/Done?id=" + viewModel.DonationId;
            }
            else if (viewModel.ContributionId != null)
            {
                //Redirection page contribution
            }
            else if (viewModel.CommandId != null)
            {
                //Redirection commande payé
            }
            paymentService.CreatePayment(viewModel);
            return View(viewModel);
        }
    }
}
