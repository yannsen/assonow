using System;
using System.Collections.Generic;

namespace Projet2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int TicketsNumber { get; set; }
        public DateTime PurchaseDate { get; set; }

        //If the price of tickets changes  over time by the representative,the  eventual refund will made on the correct amount 
        public Double Amount { get; set; }

    }
}
