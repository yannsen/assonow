using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.ViewModels;
using System;
using System.Security.Claims;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Microsoft.AspNetCore.Authorization;

namespace Projet2.Controllers
{
    public class AssociationController : Controller
    {
            private IAssociationService associationService;
            BddContext _bddContext;
  

        public AssociationController()
        {
            this.associationService = new AssociationService();
            this._bddContext = new BddContext();
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

            Association association = associationService.GetAssociation((int)id);
            if (association == null)
            {
                return NotFound();
            }
            return View(association);
        }

        public IActionResult ListeDesAssociations()
        {
            ListSearchAssociationViewModel viewModel = new ListSearchAssociationViewModel();
            viewModel.AssociationList = associationService.GetAllAssociations();
            return View(viewModel);

        }

        public IActionResult Rechercher(string name)
        {
            ListSearchAssociationViewModel viewModel = new ListSearchAssociationViewModel();
            viewModel.AssociationList = associationService.GetSearchAssociation(name);
            return View(viewModel);
        }
    }
}
