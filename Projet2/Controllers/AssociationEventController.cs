using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;
using System;
using System.Security.Claims;

namespace Projet2.Controllers
{
    public class AssociationEventController : Controller
    {
        private IAssociationEventService associationService;
        BddContext _bddcontext; 


        public IActionResult Index()
        {
            return View();
        }

        public AssociationEventController()
        {   
           this.associationService =new AssociationEventService();
           this._bddcontext = new BddContext();
        }

        public IActionResult Inscrire()
        {
            AssociationEventInfoViewmodel  viewModel = new AssociationEventInfoViewmodel();
            associationService.CreateAssociationEvent(viewModel, Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View(viewModel);
        }
    }
}
