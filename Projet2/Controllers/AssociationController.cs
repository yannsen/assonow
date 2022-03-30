﻿using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.ViewModels;
using System;
using System.Security.Claims;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Projet2.Controllers
{
    public class AssociationController : Controller
    {
        private IWebHostEnvironment _webEnv;
        private IAssociationService associationService;
        private IContributionService contributionService;
        private IAssociationMemberService associationMemberService;


        public AssociationController(IWebHostEnvironment environment)
        {
            this.fundraisingService = new FundraisingService();
            this.associationService = new AssociationService();
            this.contributionService = new ContributionService();
            this._webEnv = environment;
            this.associationMemberService = new AssociationMemberService();
        }

        [Authorize]
        public IActionResult Inscrire()
        {
            AssociationInfoViewModel viewModel = new AssociationInfoViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
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
                return RedirectToAction("Index", "Home");
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

        public IActionResult Join(int id)
        {
            Association association = associationService.GetAssociation(id);
            ViewBag.IsMember = false;
            if (associationMemberService.DoMembershipExist(id, Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))))
                ViewBag.IsMember = true;
            return View(association);
        }

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

        public IActionResult Joined(int id)
        {
            ViewBag.Name = associationService.GetAssociation(id).Name;
            ViewBag.Id = id;
            return View();
        }
    }
}
