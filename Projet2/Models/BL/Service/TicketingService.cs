using Projet2.Models.BL.Interface;
using System;
using Projet2.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Projet2.Models.BL.Service
{
    public class TicketingService : ITicketingService

    {
        private BddContext _bddContext;
        private IAssociationEventService associationEventService;

        public int CreateTicket(Ticket ticket)
        {
            _bddContext.Ticket.Add(ticket);
            _bddContext.SaveChanges();

            return ticket.Id;

        }

        public int CreateCartItem(CartItem cartItem)
        {
            _bddContext.CartItem.Add(cartItem);
            _bddContext.SaveChanges();

            return cartItem.Id;

        }
        public void DeleteTicket(int id)
        {

        }


    }
}





  