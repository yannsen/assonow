using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.ViewModels;
using System;
using System.Security.Claims;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace Projet2.Controllers
{
    public class AssociationController : Controller
    {
        private IWebHostEnvironment _webEnv;
        private IAssociationService associationService;
        private IDocumentService documentService;
        private IMemberService memberService;
        private IContributionService contributionService;
        private IAssociationMemberService associationMemberService;
        private IFundraisingService fundraisingService;



        public AssociationController(IWebHostEnvironment environment)
        {
            this.fundraisingService = new FundraisingService();
            this.associationService = new AssociationService();
            this.contributionService = new ContributionService();
            this.memberService = new MemberService();
            this.documentService = new DocumentService();
            this._webEnv = environment;
            this.associationMemberService = new AssociationMemberService();
        }

        [Authorize(Roles ="Member,Representative")]
        public IActionResult Inscrire()
        {
            AssociationInfoViewModel viewModel = new AssociationInfoViewModel();
            return View(viewModel);
        }

        [Authorize(Roles = "Member,Representative")]
        [HttpPost]
        public IActionResult Inscrire(AssociationInfoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                if (viewModel.File.Length > 0)
                {
                    string uploads = Path.Combine(_webEnv.WebRootPath, "FileSystem/Pictures");
                    string filePath = Path.Combine(uploads, viewModel.File.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        viewModel.File.CopyToAsync(fileStream);
                    }
                }
                viewModel.Association.Image = "/FileSystem/Pictures/" + viewModel.File.FileName;
                associationService.CreateAssociation(viewModel, Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                memberService.NewRole(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)), "Representative");
                HttpContext.SignOutAsync();
                return RedirectToAction("Connexion", "Compte");
            }
            return View(viewModel);
        }

        public IActionResult Profil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AssociationProfileViewModel viewModel = new AssociationProfileViewModel();
            viewModel.Association = associationService.GetAssociation((int)id);
            viewModel.Fundraisings = fundraisingService.GetFundraisingsByAssociation((int)id);
            return View(viewModel);
        }

        public IActionResult ListeDesAssociations()
        {
            ListSearchAssociationViewModel viewModel = new ListSearchAssociationViewModel();
            viewModel.AssociationsList = associationService.GetAllAssociations();
            return View(viewModel);

        }

        [HttpPost]
        public IActionResult ListeDesAssociations(ListSearchAssociationViewModel viewModel)
        {

            if (viewModel.SearchName == null) viewModel.SearchName = "";
            viewModel.AssociationsList = associationService.GetAssociationsToSearch(viewModel);
            return View(viewModel);
        }

        [Authorize(Roles = "Member,Representative")]
        public IActionResult Join(int id)
        {
            Association association = associationService.GetAssociation(id);
            ViewBag.IsMember = false;
            if (associationMemberService.DoMembershipExist(id, Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))))
                ViewBag.IsMember = true;
            return View(association);
        }

        [Authorize(Roles = "Member,Representative")]
        [HttpPost]
        public IActionResult Join(Association association)
        {
            associationMemberService.CreateAssociationMember(association.Id, Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            if (association.Contribution == 0)
            {
                return RedirectToAction("Joined", new { Id = association.Id });
            }
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.Amount = association.Contribution.ToString();
            paymentViewModel.ContributionId = contributionService.CreateContribution(association.Contribution, Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)), association.Id);
            return RedirectToAction("CreditCard", "Payment", paymentViewModel);
        }

        [Authorize(Roles = "Member,Representative")]
        public IActionResult Joined(int id)
        {
            ViewBag.Name = associationService.GetAssociation(id).Name;
            ViewBag.Id = id;
            return View();
        }

        [Authorize(Roles = "Representative")]
        public IActionResult Services(int id)
        {
            ServicesViewModel viewModel = new ServicesViewModel();
            Association association = associationService.GetAssociation(id);
            viewModel.TicketService = association.TicketService;
            viewModel.MemberService = association.MemberService;
            viewModel.DonationService = association.DonationService;
            viewModel.AssociationId = id;
            return View(viewModel);
        }

        [Authorize(Roles = "Representative")]
        [HttpPost]
        public IActionResult Services(ServicesViewModel viewModel)
        {
            Association association = associationService.GetAssociation(viewModel.AssociationId);
            association.TicketService = viewModel.TicketService;
            association.MemberService = viewModel.MemberService;
            association.DonationService = viewModel.DonationService;
            associationService.ModifyAssociation(association);
            return RedirectToAction("AssociationManagement", "AssociationEvent", new { Id = viewModel.AssociationId });
        }

        [Authorize(Roles = "Representative")]
        public IActionResult Documents(int id)
        {
            DocumentsViewModel viewModel = new DocumentsViewModel();
            viewModel.AssociationId = id;
            viewModel.FormerOfficialJournalPublication = documentService.GetOfficialJournalPublicationPath(id);
            viewModel.FormerRepresentativeID = documentService.GetAssociationRepresentativeIDPath(id);
            viewModel.FormerBankDetails = documentService.GetBankDetailsPath(id);
            return View(viewModel);
        }

        [Authorize(Roles = "Representative")]
        [HttpPost]
        public IActionResult Documents(DocumentsViewModel viewModel)
        {
            string fileName = "";
            if (viewModel.BankDetails != null)
            {
                if (documentService.GetBankDetails(viewModel.AssociationId) != null)
                {
                    documentService.DeleteDocument(documentService.GetBankDetails(viewModel.AssociationId).Id);
                }
                string withoutExtension = Path.GetFileNameWithoutExtension(viewModel.BankDetails.FileName);
                string extension = Path.GetExtension(viewModel.BankDetails.FileName);
                fileName = withoutExtension + "_" + viewModel.AssociationId + extension;
                string uploads = Path.Combine(_webEnv.WebRootPath, "FileSystem/Documents");
                string filePath = Path.Combine(uploads, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.BankDetails.CopyToAsync(fileStream);
                }
                Document bankDetails = new Document();
                bankDetails.AssociationId = viewModel.AssociationId;
                bankDetails.Path = "/FileSystem/Documents/" + fileName;
                bankDetails.Type = "BankDetails";
                documentService.CreateDocument(bankDetails);
            }
            fileName = "";
            if (viewModel.RepresentativeID != null)
            {
                if (documentService.GetAssociationRepresentativeID(viewModel.AssociationId) != null)
                {
                    documentService.DeleteDocument(documentService.GetAssociationRepresentativeID(viewModel.AssociationId).Id);
                }
                string withoutExtension = Path.GetFileNameWithoutExtension(viewModel.RepresentativeID.FileName);
                string extension = Path.GetExtension(viewModel.RepresentativeID.FileName);
                fileName = withoutExtension + "_" + viewModel.AssociationId + extension;
                string uploads = Path.Combine(_webEnv.WebRootPath, "FileSystem/Documents");
                string filePath = Path.Combine(uploads, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.RepresentativeID.CopyToAsync(fileStream);
                }
                Document representativeID = new Document();
                representativeID.AssociationId = viewModel.AssociationId;
                representativeID.Path = "/FileSystem/Documents/" + fileName;
                representativeID.Type = "ID";
                documentService.CreateDocument(representativeID);
            }
            fileName = "";
            if (viewModel.OfficialJournalPublication != null)
            {
                if (documentService.GetOfficialJournalPublication(viewModel.AssociationId) != null)
                {
                    documentService.DeleteDocument(documentService.GetOfficialJournalPublication(viewModel.AssociationId).Id);
                }
                string withoutExtension = Path.GetFileNameWithoutExtension(viewModel.OfficialJournalPublication.FileName);
                string extension = Path.GetExtension(viewModel.OfficialJournalPublication.FileName);
                fileName = withoutExtension + "_" + viewModel.AssociationId + extension;
                string uploads = Path.Combine(_webEnv.WebRootPath, "FileSystem/Documents");
                string filePath = Path.Combine(uploads, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.OfficialJournalPublication.CopyToAsync(fileStream);
                }
                Document officialJournalPublication = new Document();
                officialJournalPublication.AssociationId = viewModel.AssociationId;
                officialJournalPublication.Path = "/FileSystem/Documents/" + fileName;
                officialJournalPublication.Type = "OfficialJournalPublication";
                documentService.CreateDocument(officialJournalPublication);
            }
            return RedirectToAction("AssociationManagement", "AssociationEvent", new { Id = viewModel.AssociationId });
        }

        [Authorize(Roles = "Representative")]
        public IActionResult Member(int id)
        {
            List<Member> members = associationMemberService.GetMembersForAssociation(id);
            ViewBag.AssociationId = id;
            return View(members);
        }

        [Authorize(Roles = "Representative")]
        public IActionResult DeleteMember(int memberId, int associationId)
        {
            if (associationService.GetAssociation(associationId).Contribution > 0)
                contributionService.DeleteContribution(memberId, associationId);
            associationMemberService.DeleteAssociationMember(associationMemberService.GetAssociationMember(memberId, associationId).Id);
            return RedirectToAction("Member", new { id = associationId});
        }
    }
}
