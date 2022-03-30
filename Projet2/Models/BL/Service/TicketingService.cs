using Projet2.Models.BL.Interface;
using System;
using Projet2.ViewModels;
using System.Collections.Generic;
using System.Linq;


namespace Projet2.Models.BL.Service
{
    public class TicketingService : ITicketingService
    {
        private BddContext _bddContext;

        public TicketingService()
        {
            _bddContext = new BddContext();

        }

        public int CreateOrder(int memberId, int ticketsNumber, DateTime purchaseDate, Double amount)
        {
            Order order = new Order();
            order.MemberId = memberId;
            order.TicketsNumber = ticketsNumber;
            order.PurchaseDate = purchaseDate;
            order.Amount = amount;
            _bddContext.Order.Add(order);
            _bddContext.SaveChanges();
            return order.Id;
        }

        public void CreateTicket(int position, int associationEventId, int orderId)
        {
            Ticket ticket = new Ticket();
            ticket.Position = position;
            ticket.AssociationEventId = associationEventId;
            ticket.OrderId = orderId;
            AddRemainingTicket(associationEventId);
            _bddContext.Ticket.Add(ticket);
            _bddContext.SaveChanges();
        }

        public void AddRemainingTicket (int associationEventId)
        {
            AssociationEvent associationEvent = new AssociationEvent();
            associationEvent = _bddContext.AssociationEvent.Find(associationEventId);
            if (associationEvent.TicketsTotalNumber > associationEvent.RemainingTickets)
            {
                associationEvent.RemainingTickets += 1;
            }
            _bddContext.AssociationEvent.Update(associationEvent);
            _bddContext.SaveChanges();

        }

        public void SubtractdRemainingTicket(int associationEventId)
        {
            AssociationEvent associationEvent = new AssociationEvent();
            associationEvent = _bddContext.AssociationEvent.Find(associationEventId);
            if (associationEvent.TicketsTotalNumber > associationEvent.RemainingTickets)
            {
                associationEvent.RemainingTickets -= 1;
            }
            _bddContext.AssociationEvent.Update(associationEvent);
            _bddContext.SaveChanges();

        }

        public List<Ticket> GetAllTicketByOrder(int orderId)
        {
            List<Ticket> ticketsList = _bddContext.Ticket.Where(t => t.OrderId == orderId).ToList();
             return ticketsList;
        }

        public void DeleteTicket(int TicketId)
        {
            Ticket ticket = _bddContext.Ticket.Find(TicketId);
            if (ticket != null)
            {
                _bddContext.Ticket.Remove(ticket);
                SubtractdRemainingTicket(ticket.AssociationEventId);
                _bddContext.SaveChanges();
            }

        }

        public void DeleteOrder(int orderId)
        {
            Ticket order = _bddContext.Ticket.Find(orderId);
            List<Ticket> ticketsList = GetAllTicketByOrder(orderId);
            if (order != null)
            {
                 foreach (Ticket ticket in ticketsList)
                {
                    DeleteTicket(ticket.Id);
                }
                _bddContext.Ticket.Remove(order);
                _bddContext.SaveChanges();
            }

        }
    }
}
