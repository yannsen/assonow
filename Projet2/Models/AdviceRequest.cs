using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class AdviceRequest
    {
        // Primary Key advice request's id
        public int Id { get; set; }

        // advice request's dates and times
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date du jour")]
        public DateTime Date { get; set; }

        // advice request's text from legal expert
        [Display(Name = "Votre demande : ")]
        [StringLength(2048, ErrorMessage = "Votre message ne peut pas excéder 2000 caractères ")]
        [Required(ErrorMessage = "Veuillez remplir cette demande avant d'envoyer votre message")]
        public string AdviceRequestText { get; set; }

        // advise request's status (completed / or not)
        public bool CompletedRequest { get; set; }

        // advice request's subject
        [Display(Name = "Sujet ")]
        [StringLength(100)]
        public string AdviceRequestSubject { get; set; }

        // foreign key member
        public int MemberId { get; set; }
        public Member Member { get; set; }

        // foreign key asssociation
        public int AssociationId { get; set; }
        public Association Association { get; set; }

    }
}
