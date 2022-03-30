using Microsoft.AspNetCore.Mvc;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.Models;
using Projet2.ViewModels;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

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

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create(int id)
        {
            FundraisingInfoViewModel viewModel = new FundraisingInfoViewModel();
            viewModel.AssociationId = id;
            ViewBag.Action = "Create";
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(FundraisingInfoViewModel viewModel)
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
                viewModel.Fundraising.Image = "/FileSystem/Pictures/" + viewModel.File.FileName;
                viewModel.Fundraising.AssociationId = viewModel.AssociationId;
                viewModel.Fundraising.StartingDate = DateTime.Now;
                fundraisingService.Create(viewModel);
                ViewBag.Action = "Create";
                return RedirectToAction("Management", "Fundraising", viewModel.AssociationId);
            }
            return View(viewModel);
        }

        public IActionResult Modify(int id)
        {
            FundraisingInfoViewModel viewModel = new FundraisingInfoViewModel();
            viewModel.Fundraising = fundraisingService.GetFundraising(id);
            viewModel.AssociationId = viewModel.Fundraising.AssociationId;
            ViewBag.Action = "Modify";
            return View(viewModel);
        }

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
                        string withoutExtension = Path.GetFileNameWithoutExtension(viewModel.File.FileName);
                        string extension = Path.GetExtension(viewModel.File.FileName);
                        fileName = withoutExtension + "_" + viewModel.AssociationId + "_" + viewModel.Fundraising.Id + extension;
                        string uploads = Path.Combine(_webEnv.WebRootPath, "FileSystem/Pictures");
                        string filePath = Path.Combine(uploads, fileName);
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
            return View(viewModel);
        }

        public IActionResult FundraisingList()
        {
            FundraisingListViewModel viewModel = new FundraisingListViewModel();
            viewModel.FundraisingsList = fundraisingService.GetAllFundraisings();
            viewModel.SearchIfActive = true;
            List<string> imagesList = new List<string>();
            foreach (Fundraising fundraising in viewModel.FundraisingsList)
                imagesList.Add(associationService.GetAssociationByFundraisingId(fundraising.Id).Image);
            viewModel.FundraisingsImage = imagesList;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult FundraisingList(FundraisingListViewModel viewModel)
        {
            if (viewModel.FundraisingNameToSearch == null) viewModel.FundraisingNameToSearch = "";
            viewModel.FundraisingsList = fundraisingService.GetFundraisingsToSearch(viewModel);
            List<string> imagesList = new List<string>();
            foreach (Fundraising fundraising in viewModel.FundraisingsList)
                imagesList.Add(associationService.GetAssociationByFundraisingId(fundraising.Id).Image);
            viewModel.FundraisingsImage = imagesList;
            return View(viewModel);
        }

        public IActionResult Management(int id)
        {
            FundraisingManagementViewModel viewModel = new FundraisingManagementViewModel();
            viewModel.Fundraisings = fundraisingService.GetFundraisingsByAssociation(id);
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
