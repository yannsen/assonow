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
    public class TicketingController : Controller
    {
        private ITicketingService TicketingService;
        BddContext _bddContext;

        public TicketingController()
        {
            this.TicketingService = new TicketingService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TicketRegister(int Id,int TicketsNumber, int Price)
        {

            TicketingViewModel viewModel = new TicketingViewModel();

           
            //viewModel.ticket.AssociationEventId = EventId;
            //viewModel.ticket.Position = TicketNumber;

            //viewModel.cartItem.TicketId = TicketingService.CreateTicket(viewModel.ticket);

           // viewModel.cartItem.TicketId;

            return RedirectToAction("EventView", "AssociationEvent", new { id = Id, });


            // controle que le nombre max n est pas atteint
            //la position  indique le numero du ticket


        }
    }
}
