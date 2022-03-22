using System;

namespace Projet2.Models
{
    public class AssociationEvent
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
      //  public string Video { get; set; }
        public DateTime Date { get; set; }
        
        public string EventType { get; set; }
        public string? Speakers { get; set; }
        public string? Artists { get; set; }

        public int TicketsTotalNumber { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }

    }
}
