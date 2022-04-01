using Microsoft.AspNetCore.Mvc;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;
using Projet2.Models;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Projet2.Controllers
{
    public class PaymentController : Controller
    {
        private IPaymentService paymentService;
        private IFundraisingService fundraisingService;
        private ICreditCardService creditCardService;
        private IDonationService donationService;
        private BddContext _bddContext;

        public PaymentController()
        {
            this.paymentService = new PaymentService();
            this.creditCardService = new CreditCardService();
            this.fundraisingService = new FundraisingService();
            this.donationService = new DonationService();
            this._bddContext = new BddContext();
        }

        [Authorize(Roles = "Member,Representative")]
        public IActionResult CreditCard (PaymentViewModel paymentViewModel)
        {
            PaymentCreditCardViewModel viewModel = new PaymentCreditCardViewModel();
            viewModel.SavedCreditCard = creditCardService.GetSavedCard(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            viewModel.PaymentViewModel = paymentViewModel;
            return View(viewModel);
        }

        [Authorize(Roles = "Member,Representative")]
        [HttpPost]
        public IActionResult CreditCard(string submitButton, PaymentCreditCardViewModel viewModel)
        {
            if(submitButton == "Changer de carte")
            {
                viewModel.SavedCreditCard = null;
                return View(viewModel);
            }
            if (ModelState.IsValid)
            {
                if (viewModel.SaveCard == true)
                {
                    viewModel.NewCreditCard.MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    creditCardService.SaveCard(viewModel.NewCreditCard);
                }
                return RedirectToAction("Validation", "Payment", viewModel.PaymentViewModel);
            }
            return View(viewModel);
        }

        [Authorize(Roles = "Member,Representative")]
        public IActionResult Validation(PaymentViewModel viewModel)
        {
            if (viewModel.DonationId != null)
            {
                ViewBag.Next = "../Donation/Done?id=" + viewModel.DonationId;
                if (donationService.IsForFundraising((int)viewModel.DonationId))
                    fundraisingService.AddAmount(fundraisingService.GetFundraisingByDonationId((int)viewModel.DonationId).Id, Int32.Parse(viewModel.Amount));
            }
            else if (viewModel.ContributionId != null)
            {
                ViewBag.Next = "../Association/Joined?id=" + viewModel.ContributionId;
            }
            else if (viewModel.CommandId != null)
            {
                ViewBag.Next = "../AssociationEvent/EventView?id=" + viewModel.CommandId;
            }
            paymentService.CreatePayment(viewModel);
            return View(viewModel);
        }
    }
}
