using System.ComponentModel.DataAnnotations;
using System;

namespace Projet2.Models
{
    public class AssociationEvent
    {
        [Key]    
        public int Id { get; set; }

        [Display(Name = "Nom : ")]
        [Required(ErrorMessage = "Le Nom de l'évènement est obligatoire")]

        public string EventTitle { get; set; }

        [Display(Name = "Description : ")]
        public string Description { get; set; }

        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date :")]
        [Required(ErrorMessage = "Veuillez indiquer la date de l'événement")]
        public DateTime Date { get; set; }
        [Display(Name = "Type d'événement :")]
        [Required(ErrorMessage = "Veuillez sélectionner un type d'événement")]

        public string EventType { get; set; }

#nullable enable
        [Display(Name = "Conférencier.e.s :")]
#nullable enable
        public string? Speakers { get; set; }

        [Display(Name = "Artiste.s :")]
        public string? Artists { get; set; }
#nullable disable

        [Display(Name = "Nombre de places :")]
        [Required(ErrorMessage = "Quel est le nombre de ticket")]
        public int TicketsTotalNumber { get; set; }
        public int RemainingTickets { get; set; }
        public bool IsHighlighted { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }

        [Display(Name = "Prix d'une place : ")]
        [Required(ErrorMessage = "Quel est le prix d'une place")]
        public double TicketPrice { get; set; }


    }
}
