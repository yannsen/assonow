using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;
using System;
using System.Collections.Generic;
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
            this.associationEventService = new AssociationEventService();
            this._bddcontext = new BddContext();
        }

        public IActionResult Inscrire()
        {
            //List<AssociationSelectViewModel> associationsOfRepresentative = new List<AssociationSelectViewModel>();
            //Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))

            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.AssociationList = associationEventService.AssociationsRepresentative(2);
            
            
            //foreach (Association association in associationList)
            //{
            //    associationsOfRepresentative.Add(new AssociationSelectViewModel { Id = association.Id, Name = association.Name });

            //}

            //AssociationChoiceViewModel viewModel = new AssociationChoiceViewModel();
            //viewModel.AssociationsOfRepresentative = associationsOfRepresentative;
            //viewModel.AssociationEventInfo = new AssociationEventInfoViewmodel();
            

            //ViewBag.assoListe = viewModel.AssociationList;
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
