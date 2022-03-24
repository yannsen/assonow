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
        private BddContext _bddContext;

        public DonationController()
        {
            this.donationService = new DonationService();
            this._bddContext = new BddContext();
        }

        public IActionResult Association(int AssociationId)
        {
            DonationViewModel viewModel = new DonationViewModel();
            viewModel.AssociationId = AssociationId;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Association(DonationViewModel viewModel)
        {
            viewModel.MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            donationService.CreateDonation(viewModel);
            return View(viewModel);
        }
        
        public IActionResult Collecte(int FundraisingId)
        {
            DonationViewModel viewModel = new DonationViewModel();
            viewModel.FundraisingId = FundraisingId;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Collecte(DonationViewModel viewModel)
        {
            viewModel.MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            donationService.CreateDonation(viewModel);
            return View(viewModel);
        }
    }
}
