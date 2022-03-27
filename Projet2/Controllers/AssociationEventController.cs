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
        private IAssociationService associationService;
        BddContext _bddContext;

        public AssociationEventController()
        {
            this.associationEventService = new AssociationEventService();
            this.associationService = new AssociationService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            List<Association> associationsList = associationEventService.AssociationsRepresentative(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            if (associationsList.Count == 1)
            {
               return RedirectToAction("AssociationManagement", "AssociationEvent", new { Id = associationsList[0].Id });
            }
           
            return View(associationsList);
        }

        public IActionResult AssociationManagement(int id)
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.SelectedAssociationId= id;

                return View(viewModel);
        }


        public IActionResult EventManagement()
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.AssociationList = associationEventService.AssociationsRepresentative(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            if (viewModel.AssociationList.Count > 1   )
            {
                return View();
            }
            return View();

        }

        //register new Event for a specific association
        public IActionResult EventRegister(int id)
        {

            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.AssociationEvent = new AssociationEvent();
            viewModel.SelectedAssociationId = id;
            return View(viewModel);

        }

        [HttpPost]
        [Authorize]
        public IActionResult EventRegister(AssociationEventInfoViewmodel viewModel)
        {   
            viewModel.AssociationEvent.AssociationId = viewModel.SelectedAssociationId;
            if (ModelState.IsValid)
            {

                associationEventService.CreateAssociationEvent(viewModel);
                return RedirectToAction("EventList", "AssociationEvent",new {id= viewModel.SelectedAssociationId});
            }
            else { Console.WriteLine(" ModelState false"); }
            return View(viewModel);
        }

        //List of all event of  an association. 
        //id in parameter is for Id of association
        public ActionResult EventList(int id)
        {
                AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
                viewModel.EventsList = associationEventService.ListAssociationEvent(id);
                viewModel.SelectedAssociationId = id;
                return View(viewModel);

        }


        public ActionResult EventDelete(int id,int eventid)
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            associationEventService.DeleteAssociationEvent(eventid);
            viewModel.SelectedAssociationId = id;
            return View(viewModel);
        }
        public ActionResult EventEdit(int id)
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.AssociationEvent = _bddContext.AssociationEvent.Find(id);
            viewModel.Address = _bddContext.Address.Find(viewModel.AssociationEvent.AddressId);
            ViewBag.Legend = "Modification du compte";
            return View(viewModel);
            
        }

        [HttpPost]
        public ActionResult EventEdit(AssociationEventInfoViewmodel viewModel)
        {  
            if (ModelState.IsValid)
            {
                associationEventService.ModifyAssociationEvent(viewModel);
                return View(viewModel);
            }
            return View(viewModel);
            
        }

    }
}
