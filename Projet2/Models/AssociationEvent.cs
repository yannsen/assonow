<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
using System;

=======
﻿using System;
using System.ComponentModel.DataAnnotations;

>>>>>>> fatoumata
namespace Projet2.Models
{
    public class AssociationEvent
    {
        public int Id { get; set; }
<<<<<<< HEAD

        [Display(Name = "Nom de l'évènement :")]
        [Required(ErrorMessage = "Le Nom de l'évènement est obligatoire")]

=======
        [Display(Name = "Titre de l'événement :")]
        [Required(ErrorMessage = "Veuillez indiquer le titre de l'événement")]
>>>>>>> fatoumata
        public string EventTitle { get; set; }

        [Display(Name = "Description  de l'évènement :")]
        public string Description { get; set; }
<<<<<<< HEAD

        public string? Image { get; set; }
      //  public string Video { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Type  d'évènement :")]
=======
        public string Image { get; set; }
        //  public string Video { get; set; }
        [Display(Name = "Date:")]
        [Required(ErrorMessage = "Veuillez indiquer la date de l'événement")]
        public DateTime Date { get; set; }
        [Display(Name = "Type d'événement :")]
        [Required(ErrorMessage = "Veuillez sélectionner un type d'événement")]
>>>>>>> fatoumata
        public string EventType { get; set; }

        [Display(Name = "Conférencier.e.s :")]
        public string? Speakers { get; set; }

        [Display(Name = "Artiste.s :")]
        public string? Artists { get; set; }
<<<<<<< HEAD

        [Display(Name = "Nombre de tickets :")]
        public int? TicketsTotalNumber { get; set; }
=======
        [Display(Name = "Nombre de tickets :")]
        [Required(ErrorMessage = "Quel est le nombre de ticket")]
        public int TicketsTotalNumber { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
>>>>>>> fatoumata

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }

    }
}
