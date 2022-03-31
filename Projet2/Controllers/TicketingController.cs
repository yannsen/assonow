using Microsoft.AspNetCore.Mvc;
using Projet2.Models;
using Projet2.Models.BL.Interface;
using Projet2.Models.BL.Service;
using Projet2.ViewModels;
using System;
using System.Security.Claims;

namespace Projet2.Controllers
{
    public class TicketingController : Controller
    {

        private ITicketingService ticketingService;
        private BddContext _bddContext;

        public TicketingController()
        {
            this.ticketingService = new TicketingService();
            this._bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            return View();
        }
        //id =eventId
        public IActionResult TicketRegister(int id,int RemainingTicket)

        {
            TicketingViewModel viewModel = new TicketingViewModel();
            AssociationEvent associationEvent = new AssociationEvent();
            associationEvent = _bddContext.AssociationEvent.Find(id);
            viewModel.TicketPrice = associationEvent.TicketPrice;
            viewModel.EventTitle = associationEvent.EventTitle;
            viewModel.EventId = id;
            viewModel.RemainingTicket=RemainingTicket;
            viewModel.Position = associationEvent.TicketsTotalNumber - viewModel.RemainingTicket-1;



            return View(viewModel);
        }
        [HttpPost]
        public IActionResult TicketRegister(TicketingViewModel viewModel)

        {
            int _OrderId;
            int _MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            DateTime _PurchaseDate = DateTime.Now;
            viewModel.Amount = viewModel.TicketPrice * viewModel.TicketsNumber;
            viewModel.Position=

             _OrderId = ticketingService.CreateOrder(_MemberId, viewModel.TicketsNumber, _PurchaseDate, viewModel.Amount);
            for (int i = 1; i <= viewModel.TicketsNumber; i++)
            {
                viewModel.Position += 1;
                ticketingService.CreateTicket(viewModel.Position, viewModel.EventId, _OrderId);
            }
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.Amount = viewModel.Amount.ToString();


            //PB pour enregistrer les tckets et la commande si ici cela est fait avant validation de la commande
            //PB bis entre donationID et eventID
            paymentViewModel.DonationId = viewModel.EventId;
            return RedirectToAction("CreditCard", "Payment", paymentViewModel);
        }
   

        public IActionResult MemberTicketList()

        {
            TicketingViewModel viewModel = new TicketingViewModel();
            viewModel.TicketsList = ticketingService.ListMemberTicket(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            viewModel.SelectedAssociationId = id;
            return View(viewModel);

            return View();
        }
    
    }




}

