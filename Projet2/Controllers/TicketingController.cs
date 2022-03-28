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
        //private IAssociationService associationService;
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

        public IActionResult TicketRegister(int EventId,int TicketNumber, int Price, int MemberID)
        {

            TicketingService viewModel = new TicketingService();
            //int CreateTicket()
           // viewModel.Tic = id;
            return View(viewModel);


            // controle que le nombre max n est pas atteint
            //la position  indique le numero du ticket

            return View();
        }
    }
}
