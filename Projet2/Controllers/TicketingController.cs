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
        public IActionResult TicketRegister(int id)//,int RemainingTicket)

        {
            TicketingViewModel viewModel = new TicketingViewModel();
            AssociationEvent associationEvent = new AssociationEvent();
            associationEvent = _bddContext.AssociationEvent.Find(id);
            viewModel.TicketPrice = associationEvent.TicketPrice;
            viewModel.EventTitle = associationEvent.EventTitle;
            viewModel.EventId = id;
            viewModel.RemainingTicket = associationEvent.RemainingTickets;//RemainingTicket;
            viewModel.Threshold = 10*Convert.ToInt32(associationEvent.TicketsTotalNumber)/100;
            viewModel.Position = associationEvent.TicketsTotalNumber - viewModel.RemainingTicket;



            return View(viewModel);
        }
        [HttpPost]
        public IActionResult TicketRegister(TicketingViewModel viewModel)

        {
            int _OrderId;
            int _MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            DateTime _PurchaseDate = DateTime.Now;
            viewModel.Amount = viewModel.TicketPrice * viewModel.TicketsNumber;

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
            paymentViewModel.CommandId = viewModel.EventId;
            return RedirectToAction("CreditCard", "Payment", paymentViewModel);
        }
   

        public IActionResult MemberOrderList()

        {
            TicketingViewModel viewModel = new TicketingViewModel();
            viewModel.OrderByEventList = new List<OrderByEvent>();
            viewModel.OrderList = ticketingService.ListAllOrderByMember(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            
            foreach (Order order in viewModel.OrderList)
            {
                AssociationEvent associationEvent = ticketingService.GetAssociationEventByOrder(order.Id)[0];

                OrderByEvent orderByEvent = new OrderByEvent();
                orderByEvent.TicketsNumber = order.TicketsNumber;
                orderByEvent.Amount = order.Amount;
                orderByEvent.EventTitle = associationEvent.EventTitle;
                orderByEvent.IdEvent = associationEvent.Id;
                orderByEvent.Image = associationEvent.Image;
                orderByEvent.IdOrder = order.Id;

                viewModel.OrderByEventList.Add(orderByEvent);
            }

            return View(viewModel);
        }
    
        public IActionResult PurchasedEventDelete(int orderId)
        {
            ticketingService.DeleteOrder(orderId);

            return View();
        }
        //localhost:5000/ticketing/PurchasedEventModify?id=1&idOrder=1
        public IActionResult PurchasedEventModify(int id,int idOrder)
        {
            TicketingViewModel viewModel = new TicketingViewModel();
            AssociationEvent associationEvent = new AssociationEvent();
            Order order = _bddContext.Order.Find(idOrder);
            associationEvent = _bddContext.AssociationEvent.Find(id);
            viewModel.TicketPrice = associationEvent.TicketPrice;
            viewModel.EventTitle = associationEvent.EventTitle;
            viewModel.EventId = id;
            viewModel.RemainingTicket = associationEvent.RemainingTickets;
            viewModel.Threshold = 10 * Convert.ToInt32(associationEvent.TicketsTotalNumber) / 100;
            //viewModel.Position = associationEvent.TicketsTotalNumber - viewModel.RemainingTicket - 1;
            viewModel.TicketsNumber = order.TicketsNumber;
            viewModel.Amount = order.Amount;
            viewModel.NewAmount = order.Amount;
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult PurchasedEventModify(TicketingViewModel viewModel)
        {
            if (viewModel.NewAmount> viewModel.Amount)
            {
                viewModel.Amount = viewModel.NewAmount - viewModel.Amount;
            }
            

            int _OrderId;
            int _MemberId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            DateTime _PurchaseDate = DateTime.Now;
            viewModel.Amount = viewModel.TicketPrice * viewModel.TicketsNumber;

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

    }




}

