
﻿using System.ComponentModel.DataAnnotations;
using System;

namespace Projet2.Models
{
    public class AssociationEvent
    {
        public int Id { get; set; }

        [Display(Name = "Nom de l'évènement :")]
        [Required(ErrorMessage = "Le Nom de l'évènement est obligatoire")]

        public string EventTitle { get; set; }

        [Display(Name = "Description  de l'évènement :")]
        public string Description { get; set; }

        public string Image { get; set; }
        //  public string Video { get; set; }
        [Display(Name = "Date:")]
        [Required(ErrorMessage = "Veuillez indiquer la date de l'événement")]
        public DateTime Date { get; set; }
        [Display(Name = "Type d'événement :")]
        [Required(ErrorMessage = "Veuillez sélectionner un type d'événement")]

        public string EventType { get; set; }

        [Display(Name = "Conférencier.e.s :")]
        public string? Speakers { get; set; }

        [Display(Name = "Artiste.s :")]
        public string? Artists { get; set; }

        [Display(Name = "Nombre de tickets :")]
        [Required(ErrorMessage = "Quel est le nombre de ticket")]
        public int TicketsTotalNumber { get; set; }


        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }

    }
}
