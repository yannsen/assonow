using Microsoft.AspNetCore.Authorization;
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

        public AssociationEventController()
        {
            this.associationEventService = new AssociationEventService();
            this._bddcontext = new BddContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EventManagement()
        {
            return View();
        }


        public IActionResult Inscrire()
        {

            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.AssociationList = associationEventService.AssociationsRepresentative(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View(viewModel);

        }

        [HttpPost]
        [Authorize]
        public IActionResult Inscrire(AssociationEventInfoViewmodel viewModel)
        {
            viewModel.AssociationEvent.AssociationId = viewModel.SelectedAssociationId;
            if (ModelState.IsValid)
            {

                associationEventService.CreateAssociationEvent(viewModel);
                return RedirectToAction("Index", "Home");
            }
            else { Console.WriteLine(" ModelState false"); }
            return View(viewModel);
        }


        public ActionResult EventList()
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.EventsList = associationEventService.ListAssociationEvent(2);
           
            return View(viewModel);
        }



        //public ActionResult EventDelete(Data model)
        //{
        //    //Code for delete
        //    return View("Index", data);
        //}

        //[HttpGet]
        //public ActionResult EventEdit()
        //{
        //    //code for binding the existing records
        //    return View(_data);
        //}



        //[HttpPost]
        //public ActionResult EditEvent(string sampleDropdown, Data model)
        //{
        //    //code for saving the updated data
        //    return RedirectToAction("Index", "Home");

        //}

    }
}
