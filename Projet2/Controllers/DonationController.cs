using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;
using System;
using System.Security.Claims;

namespace Projet2.Controllers
{
    public class DonationController : Controller
    {
        private IDonationService donationService;
        private IAssociationService associationService;
        private IFundraisingService fundraisingService;
        private BddContext _bddContext;

        public DonationController()
        {
            this.donationService = new DonationService();
            this.associationService = new AssociationService();
            this.fundraisingService = new FundraisingService();
            this._bddContext = new BddContext();
        }

        [Authorize(Roles = "Member,Representative")]
        public IActionResult Association(int id)
        {
            DonationViewModel viewModel = new DonationViewModel();
            viewModel.Association = associationService.GetAssociation(id);
            return View(viewModel);
        }

        [Authorize(Roles = "Member,Representative")]
        [HttpPost]
        public IActionResult Association(DonationViewModel viewModel)
        {
            viewModel.MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            int donationId = donationService.CreateDonation(viewModel);
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.Amount = viewModel.Amount;
            paymentViewModel.DonationId = donationId;
            return RedirectToAction("CreditCard", "Payment", paymentViewModel);
        }

        [Authorize(Roles = "Member,Representative")]
        public IActionResult Fundraising(int id)
        {
            DonationViewModel viewModel = new DonationViewModel();
            viewModel.Fundraising = fundraisingService.GetFundraising(id);
            return View(viewModel);
        }

        [Authorize(Roles = "Member,Representative")]
        [HttpPost]
        public IActionResult Fundraising(DonationViewModel viewModel)
        {
            viewModel.MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            int donationId = donationService.CreateDonation(viewModel);
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.Amount = viewModel.Amount;
            paymentViewModel.DonationId = donationId;
            return RedirectToAction("CreditCard", "Payment", paymentViewModel);
        }

        [Authorize(Roles = "Member,Representative")]
        public IActionResult Done(int id)
        {
            DonationThanksViewModel viewModel = new DonationThanksViewModel();
            if (donationService.GetDonation(id).AssociationId != null)
            {
                Association association = associationService.GetAssociationByDonationId(id);
                viewModel.Association = association;
            }
            else
            {
                Fundraising fundraising = fundraisingService.GetFundraisingByDonationId(id);
                Association association = associationService.GetAssociationByFundraisingId(fundraising.Id);
                viewModel.Fundraising = fundraising;
                viewModel.Association = association;
                viewModel.IsForFundraising = true;
            }
            return View(viewModel);
        }
    }
}
