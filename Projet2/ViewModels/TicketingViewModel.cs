using Projet2.Models;
using System.Collections.Generic;


namespace Projet2.ViewModels
{
    public class TicketingViewModel
    {
        public string EventTitle { get; set; }
        public int EventId { get; set; }
        public double TicketPrice { get; set; }

        public int TicketsNumber { get; set; }
        public double Amount { get; set; }
        public int RemainingTicket { get; set; }

        public int Position { get; set; }

       public List<Ticket>TicketsList { get; set; }


    }

}
