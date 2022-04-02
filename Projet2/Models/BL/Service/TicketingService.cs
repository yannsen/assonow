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
            SubtractdRemainingTicket(associationEventId);
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
                AddRemainingTicket(ticket.AssociationEventId);
                _bddContext.SaveChanges();
            }

        }

        public void DeleteOrder(int orderId)
        {
            Order order = _bddContext.Order.Find(orderId);
            _bddContext.Order.Remove(order);
            _bddContext.SaveChanges();
            List<Ticket> ticketsList = GetAllTicketByOrder(orderId);
            if (order != null)
            {
                 foreach (Ticket ticket in ticketsList)
                {
                    DeleteTicket(ticket.Id);
                }

            }
        }
        // select * from ticket where OrderId == (select id from order where memberId = idmember;
        public List<Order> ListAllOrderByMember(int IdMember)
        {       
            return _bddContext.Order.Where(O => O.MemberId == IdMember).ToList(); ;
        }

        // select * from AssociationEvent where Id == (select EventId from Ticket where OrderId = idOrder;
        public List<AssociationEvent> GetAssociationEventByOrder(int IdOrder)
        {
            var request = from ae in _bddContext.AssociationEvent
                          let tic = from t in _bddContext.Ticket
                                    where  t.OrderId == IdOrder
                                    select t.AssociationEventId
                          where tic.Contains(ae.Id)
                                    select ae;

            return request.ToList();

        }

    }
}
