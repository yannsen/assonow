﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;

namespace Projet2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminDashboardController : Controller
    {
        private IAssociationService associationService;
        private IFundraisingService fundraisingService;
        private IAddressService addressService;
        private IDocumentService documentService;
        BddContext _bddContext;

        public AdminDashboardController()
        {
            this.addressService = new AddressService();
            this.fundraisingService = new FundraisingService();
            this.associationService = new AssociationService();
            this.documentService = new DocumentService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DemandeInscription(int? result, int? id)
        {
            if(result != null)
            {
                if (result == 0)
                    associationService.DeleteAssociation((int)id);
                else
                    associationService.ValidateAssociation((int)id);
            }
            SubscriptionRequestViewModel viewModel = new SubscriptionRequestViewModel();
            viewModel.unpublishedAssociations = associationService.GetAssociationSelectList();
            if (viewModel.unpublishedAssociations.Count > 0)
            {
                viewModel.AssociationInfo = new AssociationInfoViewModel();
                viewModel.AssociationInfo.Association = associationService.GetAssociation(viewModel.unpublishedAssociations[0].Id);
                viewModel.AssociationInfo.Address = addressService.GetAddressByAssociationId(viewModel.unpublishedAssociations[0].Id);
                viewModel.BankDetails = documentService.GetBankDetails(viewModel.unpublishedAssociations[0].Id);
                viewModel.OfficialJournalPublication = documentService.GetOfficialJournalPublication(viewModel.unpublishedAssociations[0].Id);
                viewModel.RepresentativeID = documentService.GetAssociationRepresentativeID(viewModel.unpublishedAssociations[0].Id);
                ViewBag.Id = viewModel.unpublishedAssociations[0].Id;
                viewModel.estVide = false;
            }
            else
            {
                viewModel.estVide = true;
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DemandeInscription(SubscriptionRequestViewModel viewModel)
        {
            viewModel.AssociationInfo = new AssociationInfoViewModel();
            viewModel.AssociationInfo.Association = associationService.GetAssociation(viewModel.SelectedAssociationId);
            viewModel.AssociationInfo.Address = addressService.GetAddressByAssociationId(viewModel.SelectedAssociationId);
            viewModel.unpublishedAssociations = associationService.GetAssociationSelectList();
            viewModel.BankDetails = documentService.GetBankDetails(viewModel.SelectedAssociationId);
            viewModel.OfficialJournalPublication = documentService.GetOfficialJournalPublication(viewModel.SelectedAssociationId);
            viewModel.RepresentativeID = documentService.GetAssociationRepresentativeID(viewModel.SelectedAssociationId);
            ViewBag.Id = viewModel.SelectedAssociationId;
            return View(viewModel);
        }

        public IActionResult HighlightedAssociations()
        {
            HighlightedViewModel viewModel = new HighlightedViewModel();
            viewModel.HAssociations = associationService.GetHighlightedAssociations();
            viewModel.NHAssociations = associationService.GetNotHighlightedAssociations();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult HighlightedAssociations(HighlightedViewModel viewModel)
        {
            bool H = associationService.GetHighlightedAssociations().Count > 0;
            bool NH = associationService.GetNotHighlightedAssociations().Count > 0;
            if (H)
            {
                foreach (Association association in viewModel.HAssociations)
                {
                    Association associationToUpdate = associationService.GetAssociation(association.Id);
                    associationToUpdate.IsHighlighted = association.IsHighlighted;
                    associationService.ModifyAssociation(associationToUpdate);
                }
            }
            if (NH)
            {
                foreach (Association association in viewModel.NHAssociations)
                {
                    Association associationToUpdate = associationService.GetAssociation(association.Id);
                    associationToUpdate.IsHighlighted = association.IsHighlighted;
                    associationService.ModifyAssociation(associationToUpdate);
                }
            }
            return RedirectToAction("HighlightedAssociations");
        }

        public IActionResult HighlightedFundraisings()
        {
            HighlightedViewModel viewModel = new HighlightedViewModel();
            viewModel.HFundraisings = fundraisingService.GetHighlightedFundraisings();
            viewModel.NHFundraisings = fundraisingService.GetNotHighlightedFundraisings();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult HighlightedFundraisings(HighlightedViewModel viewModel)
        {
            bool H = fundraisingService.GetHighlightedFundraisings().Count > 0;
            bool NH = fundraisingService.GetNotHighlightedFundraisings().Count > 0;
            if (H)
            {
                foreach (Fundraising fundraising in viewModel.HFundraisings)
                {
                    Fundraising fundraisingToUpdate = fundraisingService.GetFundraising(fundraising.Id);
                    fundraisingToUpdate.IsHighlighted = fundraising.IsHighlighted;
                    fundraisingService.Modify(fundraisingToUpdate);
                }
            }
            if (NH)
            {
                foreach (Fundraising fundraising in viewModel.NHFundraisings)
                {
                    Fundraising fundraisingToUpdate = fundraisingService.GetFundraising(fundraising.Id);
                    fundraisingToUpdate.IsHighlighted = fundraising.IsHighlighted;
                    fundraisingService.Modify(fundraisingToUpdate);
                }
            }
            return RedirectToAction("HighlightedFundraisings");
        }
    }
}
