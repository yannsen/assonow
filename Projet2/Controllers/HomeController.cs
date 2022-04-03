using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.ViewModels;
using System.Collections.Generic;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;

namespace Projet2.Controllers
{
    public class HomeController : Controller
    {
        private IAssociationService associationService;
        private IFundraisingService fundraisingService;
        private IAssociationEventService associationEventService;

        BddContext _bddContext;
        public HomeController()
        {
            this.associationService = new AssociationService();
            this.fundraisingService = new FundraisingService();
            this.associationEventService = new AssociationEventService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Associations =  associationService.GetHighlightedAssociations();
            viewModel.Fundraisings = fundraisingService.GetHighlightedFundraisings();
            viewModel.AssociationEvents = associationEventService.GetHighlightedAssociationEvents();
            return View(viewModel);
        }
    }

}
