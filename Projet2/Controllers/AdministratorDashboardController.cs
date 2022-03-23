using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using System.Collections.Generic;
using Projet2.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Projet2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminDashboardController : Controller
    {
        private IAssociationService associationService;
        private IAddressService addressService;
        BddContext _bddContext;

        public AdminDashboardController()
        {
            this.addressService = new AddressService();
            this.associationService = new AssociationService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DemandeInscription()
        {
            List<AssociationSelectViewModel> unpublishedAssociations = new List<AssociationSelectViewModel>();
            List<Association> associationList= associationService.GetUnpublishedAssociations();
            foreach (Association association in associationList)
            {
                unpublishedAssociations.Add(new AssociationSelectViewModel { Id = association.Id, Name = association.Name });
            }
            SubscriptionRequestViewModel viewModel = new SubscriptionRequestViewModel();
            viewModel.unpublishedAssociations = unpublishedAssociations;
            ViewBag.Id = 0;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DemandeInscription(SubscriptionRequestViewModel viewModel)
        {
            viewModel.AssociationInfo = new AssociationInfoViewModel();
            viewModel.AssociationInfo.Association = associationService.GetAssociation(viewModel.SelectedAssociationId);
            viewModel.AssociationInfo.Address = addressService.GetAddressByAssociationId(viewModel.SelectedAssociationId);
            ViewBag.Id = viewModel.SelectedAssociationId;
            return View(viewModel);
        }
    }
}
