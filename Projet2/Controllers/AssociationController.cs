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

namespace Projet2.Controllers
{
    public class AssociationController : Controller
    {
        private IWebHostEnvironment _webEnv;
        private IAssociationService associationService;
        BddContext _bddContext;
  

        public AssociationController(IWebHostEnvironment environment)
        {
            this.associationService = new AssociationService();
            this._webEnv = environment;
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
    }
}
