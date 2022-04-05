using Microsoft.AspNetCore.Mvc;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.Models;
using Projet2.ViewModels;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Projet2.Controllers
{
    public class FundraisingController : Controller
    {
        private IWebHostEnvironment _webEnv;
        private IFundraisingService fundraisingService;
        private IAssociationService associationService;
        private BddContext _bddContext;

        public FundraisingController(IWebHostEnvironment environment)
        {
            this._webEnv = environment;
            this.associationService = new AssociationService();
            this.fundraisingService = new FundraisingService();
            this._bddContext = new BddContext();
        }

        [Authorize(Roles = "Representative")]
        public IActionResult Create(int id)
        {
            FundraisingInfoViewModel viewModel = new FundraisingInfoViewModel();
            viewModel.AssociationId = id;
            ViewBag.Association = associationService.GetAssociation(id);
            ViewBag.Action = "Create";
            return View(viewModel);
        }

        [Authorize(Roles = "Representative")]
        [HttpPost]
        public IActionResult Create(FundraisingInfoViewModel viewModel)
        {
            ModelState.Remove("Fundraising.Id");
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (viewModel.File.Length > 0)
                {
                    Random rnd = new Random();
                    string withoutExtension = Path.GetFileNameWithoutExtension(viewModel.File.FileName);
                    string extension = Path.GetExtension(viewModel.File.FileName);
                    fileName = withoutExtension + "_" + rnd.Next(1, 100000).ToString() + extension;
                    string uploads = Path.Combine(_webEnv.WebRootPath, "FileSystem/Pictures");
                    string filePath = Path.Combine(uploads, fileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        viewModel.File.CopyToAsync(fileStream);
                    }
                }
                viewModel.Fundraising.Image = "/FileSystem/Pictures/" + fileName;
                viewModel.Fundraising.AssociationId = viewModel.AssociationId;
                viewModel.Fundraising.StartingDate = DateTime.Now;
                viewModel.Fundraising.IsActive = true;
                fundraisingService.Create(viewModel);
                ViewBag.Action = "Create";
                return RedirectToAction("Management", "Fundraising", new { id = viewModel.AssociationId });
            }
            ViewBag.Association = associationService.GetAssociation(viewModel.AssociationId);
            return View(viewModel);
        }

        [Authorize(Roles = "Representative")]
        public IActionResult Modify(int id)
        {
            FundraisingInfoViewModel viewModel = new FundraisingInfoViewModel();
            viewModel.Fundraising = fundraisingService.GetFundraising(id);
            viewModel.AssociationId = viewModel.Fundraising.AssociationId;
            ViewBag.Association = associationService.GetAssociation(viewModel.Fundraising.AssociationId);
            ViewBag.Action = "Modify";
            return View(viewModel);
        }

        [Authorize(Roles = "Representative")]
        [HttpPost]
        public IActionResult Modify(FundraisingInfoViewModel viewModel)
        {
            ModelState.Remove("File");
            if (ModelState.IsValid)
            {
                if (viewModel.File != null)
                {
                    string fileName = "";
                    if (viewModel.File.Length > 0)
                    {

                        Random rnd = new Random();
                        string withoutExtension = Path.GetFileNameWithoutExtension(viewModel.File.FileName);
                        string extension = Path.GetExtension(viewModel.File.FileName);
                        fileName = withoutExtension + "_" + rnd.Next(1, 100000).ToString() + extension;
                        string uploads = Path.Combine(_webEnv.WebRootPath, "FileSystem/Pictures");
                        string filePath = Path.Combine(uploads, fileName);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            viewModel.File.CopyToAsync(fileStream);
                        }
                    }
                    viewModel.Fundraising.Image = "/FileSystem/Pictures/" + fileName;
                }
                fundraisingService.Modify(viewModel.Fundraising);
                ViewBag.Action = "Modify";
                return RedirectToAction("Management", new { Id = viewModel.AssociationId });
            }
            ViewBag.Association = associationService.GetAssociation(viewModel.AssociationId);
            return View(viewModel);
        }

        public IActionResult FundraisingList()
        {
            FundraisingListViewModel viewModel = new FundraisingListViewModel();
            viewModel.FundraisingsList = fundraisingService.GetAllFundraisings();
            foreach (Fundraising fundraising in viewModel.FundraisingsList)
                fundraising.Association = associationService.GetAssociation(fundraising.AssociationId);
            viewModel.SearchIfActive = true;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult FundraisingList(FundraisingListViewModel viewModel)
        {
            if (viewModel.AssociationNameToSearch == null) viewModel.AssociationNameToSearch = "";
            if (viewModel.FundraisingNameToSearch == null) viewModel.FundraisingNameToSearch = "";
            viewModel.FundraisingsList = fundraisingService.GetFundraisingsToSearch(viewModel);
            foreach (Fundraising fundraising in viewModel.FundraisingsList)
                fundraising.Association = associationService.GetAssociation(fundraising.AssociationId);
            return View(viewModel);
        }

        public IActionResult Delete(int id, int associationId)
        {
            fundraisingService.Delete(fundraisingService.GetFundraising(id));
            return RedirectToAction("Management", new { Id = associationId });
        }


        [Authorize(Roles = "Representative")]
        public IActionResult Management(int id)
        {
            FundraisingManagementViewModel viewModel = new FundraisingManagementViewModel();
            viewModel.Fundraisings = fundraisingService.GetFundraisingsByAssociation(id);
            viewModel.Association = associationService.GetAssociation(id);
            return View(viewModel);
        }

        public IActionResult Profile(int id)
        {
            Fundraising fundraising = new Fundraising();
            fundraising = fundraisingService.GetFundraising(id);
            ViewBag.AssociationImage = associationService.GetAssociationByFundraisingId(id).Image;
            return View(fundraising);
        }
    }
}
