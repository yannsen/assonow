using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class AssociationEvent
    {
        public int Id { get; set; }
        [Display(Name = "Titre de l'événement :")]
        [Required(ErrorMessage = "Veuillez indiquer le titre de l'événement")]
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        //  public string Video { get; set; }
        [Display(Name = "Date:")]
        [Required(ErrorMessage = "Veuillez indiquer la date de l'événement")]
        public DateTime Date { get; set; }
        [Display(Name = "Type d'événement :")]
        [Required(ErrorMessage = "Veuillez sélectionner un type d'événement")]
        public string EventType { get; set; }
#nullable enable
        public string? Speakers { get; set; }
        public string? Artists { get; set; }
#nullable disable
        [Display(Name = "Nombre de tickets :")]
        [Required(ErrorMessage = "Quel est le nombre de ticket")]
        public int TicketsTotalNumber { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }

    }
}
