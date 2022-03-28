using System;
using System.Collections.Generic;

namespace Projet2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        
        List<CartItem> CartItemList { get; set; }
        public DateTime Date { get; set; }

    }
}
