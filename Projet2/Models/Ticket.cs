﻿using System;

namespace Projet2.Models
{
    public class Ticket
    {
       public int Id { get; set; }
        public int Position { get; set; }
        public string Category { get; set; }
        public int OrderId { get; set; }
        public int AssociationEventId { get; set; }
        public DateTime purchaseDate { get; set; }


    }
}
