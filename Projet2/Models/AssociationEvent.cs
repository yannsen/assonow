using System;

namespace Projet2.Models
{
    public class AssociationEvent
    {
        public DateTime Date { get; set; }
        public int TicketNumber { get; set; }
        public string EventType { get; set; }
        public string? Speakers { get; set; }
        public string? Artists { get; set; }

        public int AddressId { get; set; }
        public Address Place { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }

    }
}
