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
        private IAssociationEventService associationEventService;
        BddContext _bddcontext; 


        public IActionResult Index()
        {
            return View();
        }

        public AssociationEventController()
        {   
           this.associationEventService =new AssociationEventService();
           this._bddcontext = new BddContext();
        }

        public IActionResult Inscrire()
        {
            AssociationEventInfoViewmodel  viewModel = new AssociationEventInfoViewmodel();
            return View(viewModel);
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Inscrire(AssociationEventInfoViewmodel viewModel)
        {
            if (ModelState.IsValid)
            {
                associationEventService.CreateAssociationEvent(viewModel, Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
    }
}
