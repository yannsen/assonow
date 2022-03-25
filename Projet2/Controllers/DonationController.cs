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
    [Authorize]
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

        public IActionResult Association(int id)
        {
            DonationViewModel viewModel = new DonationViewModel();
            viewModel.Association = associationService.GetAssociation(id);
            return View(viewModel);
        }

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
        
        public IActionResult Collecte(int id)
        {
            DonationViewModel viewModel = new DonationViewModel();
            viewModel.Fundraising = fundraisingService.GetFundraising(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Collecte(DonationViewModel viewModel)
        {
            viewModel.MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            int donationId = donationService.CreateDonation(viewModel);
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.Amount = viewModel.Amount;
            paymentViewModel.DonationId = donationId;
            return RedirectToAction("CreditCard", "Payment", paymentViewModel);
        }

        public IActionResult Done(int id)
        {
            Association association = associationService.GetAssociationByDonationId(id);
            return View(association);
        }
    }
}
