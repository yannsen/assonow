using Microsoft.AspNetCore.Mvc;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.Models;
using Projet2.ViewModels;
using System.Collections.Generic;

namespace Projet2.Controllers
{
    public class FundraisingController : Controller
    {
        private IFundraisingService fundraisingService;
        private IAssociationService associationService;
        private BddContext _bddContext;

        public FundraisingController()
        {
            this.associationService = new AssociationService();
            this.fundraisingService = new FundraisingService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Profile(int id)
        {
            Fundraising fundraising = new Fundraising();
            fundraising = fundraisingService.GetFundraising(id);
            ViewBag.AssociationImage = associationService.GetAssociationByFundraisingId(id).Image;
            return View(fundraising);
        }
    }
}
