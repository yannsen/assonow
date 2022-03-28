using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using System.Collections.Generic;
using Projet2.ViewModels;

namespace Projet2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminDashboardController : Controller
    {
        private IAssociationService associationService;
        private IAddressService addressService;
        private IDocumentService documentService;
        BddContext _bddContext;

        public AdminDashboardController()
        {
            this.addressService = new AddressService();
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

        public IActionResult HighlightedAssociation()
        {
            HighlightedViewModel viewModel = InitializeHighlightedViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult HighlightedAssociation(HighlightedViewModel viewModel)
        {
            bool H = associationService.GetHighlightedAssociations().Count != 0;
            bool NH = associationService.GetNotHighlightedAssociations().Count != 0;
            if (H)
            {
                foreach (KeyValuePair<int, bool> entry in viewModel.Highlighted)
                {
                    Association association = associationService.GetAssociation(entry.Key);
                    association.IsHighlighted = entry.Value;
                    associationService.ModifyAssociation(association); 
                }
            }
            if (NH)
            {
                foreach (KeyValuePair<int, bool> entry in viewModel.ToHighlight)
                {
                    Association association = associationService.GetAssociation(entry.Key);
                    association.IsHighlighted = entry.Value;
                    associationService.ModifyAssociation(association);
                }
            }
            HighlightedViewModel newViewModel = InitializeHighlightedViewModel();
            return View(newViewModel);
        }

        public HighlightedViewModel InitializeHighlightedViewModel()
        {
            HighlightedViewModel viewModel = new HighlightedViewModel();
            viewModel.Highlighted = new Dictionary<int, bool>();
            viewModel.HighlightedName = new Dictionary<int, string>();
            viewModel.ToHighlight = new Dictionary<int, bool>();
            viewModel.ToHighlightName = new Dictionary<int, string>();
            List<Association> associationsH = associationService.GetHighlightedAssociations();
            foreach (Association association in associationsH)
            {
                viewModel.Highlighted.Add(association.Id, true);
                viewModel.HighlightedName.Add(association.Id, association.Name);
            }
            List<Association> associationsNH = associationService.GetNotHighlightedAssociations();
            foreach (Association association in associationsNH)
            {
                viewModel.ToHighlight.Add(association.Id, false);
                viewModel.ToHighlightName.Add(association.Id, association.Name);
            }
                return viewModel;
        }

        public IActionResult HighlightedFundraising()
        {
            return View();
        }

        public IActionResult HighlightedEvent()
        {
            return View();
        }
    }
}
