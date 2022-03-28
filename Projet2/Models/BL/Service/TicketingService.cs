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
           

            return ticket.Id;

        }
        public void DeleteTicket(int id)
        {

        }


    }
}





  