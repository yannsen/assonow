using Microsoft.AspNetCore.Http;
using Projet2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet2.ViewModels
{
    public class TicketingViewModel
    {

       public List<CartItem> cart { get; set; }
        public Ticket ticket { get; set; }

        public Order order { get; set; }

        public CartItem cartItem { get; set; }



    }
}
