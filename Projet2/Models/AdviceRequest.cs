using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class AdviceRequest
    {
        // advice request's id
        public int Id { get; set; }

        // advice request's dates and times
        public DateTime Date { get; set; }

        // advice request's text from legal expert
        [Display(Name = "Votre demande : ")]
        [StringLength(2048, ErrorMessage = "Votre message ne peut pas excéder 2000 caractères ")]
        [Required(ErrorMessage = "Veuillez remplir cette demande avant d'envoyer votre message")]
        public string AdviceRequestText { get; set; }

        // advise request's status (completed / or not)
        public bool CompletedRequest { get; set; }

        // advice request's subject
        public string AdviceRequestSubject { get; set; }

        // foreign key member
        public int MemberId { get; set; }

        public Member Member { get; set; }

        // foreign key asssociation
        public Association Association { get; set; }

        public int AssociationId { get; set; }

    }
}
