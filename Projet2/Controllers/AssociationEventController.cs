using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

namespace Projet2.Controllers
{
    public class AssociationEventController : Controller
    {
        private IWebHostEnvironment _webEnv;
        private IAssociationEventService associationEventService;
        private IAssociationService associationService;
        BddContext _bddContext;

        public AssociationEventController(IWebHostEnvironment environment)
        {
            this.associationEventService = new AssociationEventService();
            this.associationService = new AssociationService();
            this._webEnv = environment;
            this._bddContext = new BddContext();
        }

        [Authorize(Roles = "Representative")]
        public IActionResult Index()
        {
            List<Association> associationsList = associationEventService.AssociationsRepresentative(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            if (associationsList.Count == 1)
            {
               return RedirectToAction("AssociationManagement", "AssociationEvent", new { Id = associationsList[0].Id });
            }
           
            return View(associationsList);
        }

        [Authorize(Roles = "Representative")]
        public IActionResult AssociationManagement(int id)
        {
           AssociationInfoViewModel viewModel = new AssociationInfoViewModel();
            viewModel.Association= _bddContext.Association.Find(id);

                return View(viewModel);
        }

        [Authorize(Roles = "Representative")]
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

        [Authorize(Roles = "Representative")]
        //register new Event for a specific association
        public IActionResult EventRegister(int id)
        {

            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.SelectedAssociationId = id;
            return View(viewModel);

        }

        [Authorize(Roles = "Representative")]
        [HttpPost]
        [Authorize]
        public IActionResult EventRegister(AssociationEventInfoViewmodel viewModel)
        {   
            viewModel.AssociationEvent.AssociationId = viewModel.SelectedAssociationId;
            viewModel.AssociationEvent.RemainingTickets = viewModel.AssociationEvent.TicketsTotalNumber;
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
                viewModel.AssociationEvent.Image = "/FileSystem/Pictures/" + viewModel.File.FileName;
                associationEventService.CreateAssociationEvent(viewModel);
                return RedirectToAction("EventList", "AssociationEvent",new {id= viewModel.SelectedAssociationId});
            }
            else { Console.WriteLine(" ModelState false"); }
            return View(viewModel);
        }

        //List of all event of  an association. 
        //id in parameter is for Id of association
        [Authorize(Roles = "Representative")]
        public ActionResult EventList(int id)
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.AssociationEventsList = associationEventService.ListAssociationEvent(id);
            viewModel.AssociationEventsList.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            viewModel.SelectedAssociationId = id;
            viewModel.Association = associationService.GetAssociation(id);
            return View(viewModel);

        }



        [Authorize(Roles = "Representative")]
        public ActionResult DeletedEventConfirm(int id, int eventid)
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.eventId = eventid;
            viewModel.SelectedAssociationId = id;

            return View(viewModel);

        }


        [Authorize(Roles = "Representative")]
        public ActionResult EventDelete(int id,int eventid)
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            associationEventService.DeleteAssociationEvent(eventid);
            viewModel.SelectedAssociationId = id;
            return View(viewModel);
        }

        //id in parameter is for Id of association
        [Authorize(Roles = "Representative")]
        public ActionResult EventEdit(int id, int eventid)
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.AssociationEvent = _bddContext.AssociationEvent.Find(eventid);
            viewModel.Address = _bddContext.Address.Find(viewModel.AssociationEvent.AddressId);
            viewModel.SelectedAssociationId = id;
            ViewBag.Legend = "Modification du compte";
            return View(viewModel);
            
        }

        [Authorize(Roles = "Representative")]
        [HttpPost]
        public ActionResult EventEdit(AssociationEventInfoViewmodel viewModel)
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
                viewModel.AssociationEvent.Image = "/FileSystem/Pictures/" + viewModel.File.FileName;

                associationEventService.ModifyAssociationEvent(viewModel);
                return RedirectToAction("EventList", "AssociationEvent", new { Id = viewModel.SelectedAssociationId });
            }
            return View(viewModel);
            
        }

        // view of one event with id of event as parameter
        public ActionResult EventView(int id)
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.AssociationEvent = _bddContext.AssociationEvent.Find(id);
            viewModel.Address = _bddContext.Address.Find(viewModel.AssociationEvent.AddressId);

           return View(viewModel);
        }
        
        public ActionResult VisibleEventList()
        {
            AssociationEventInfoViewmodel viewModel = new AssociationEventInfoViewmodel();
            viewModel.AssociationEventsList = associationEventService.GetAllAssociationEvents();
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult VisibleEventList(AssociationEventInfoViewmodel viewModel)
        {

            if (viewModel.AssociationNameToSearch == null) viewModel.AssociationNameToSearch = "";
            if (viewModel.EventNameToSearch == null) viewModel.EventNameToSearch = "";
            viewModel.AssociationEventsList = associationEventService.GetAssociationEventToSearch(viewModel);
            return View(viewModel);

        }



        




    }
}
