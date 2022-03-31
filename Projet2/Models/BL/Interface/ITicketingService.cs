using System;
using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface ITicketingService
    {
        public int CreateOrder(int memberId, int ticketsNumber, DateTime purchaseDate, Double amount);

        public void CreateTicket(int position, int associationEventId, int orderId);
        public List<Ticket> GetAllTicketByOrder(int orderId);
        public void DeleteTicket(int TicketId);
        public void DeleteOrder(int orderId);

        public List<Order> ListAllOrderByMember(int IdMember);

        public List<AssociationEvent> GetAssociationEventByOrder(int IdOrder);
    }
}
