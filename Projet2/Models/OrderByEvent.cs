using System;

namespace Projet2.Models
{
    public class OrderByEvent
    {
        public string EventTitle { get; set; }
        public int TicketsNumber { get; set; }
        public double   Amount { get; set; }
        
       // public DateTime PurchasedDate { get; set; }

        public int IdEvent { get; set; }

        public string Image { get; set; }

        public int IdOrder { get; set; }

    }
}
