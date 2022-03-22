using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class Advice
    {
        // advice's id
        public int Id { get; set; }

        // dates and times
        public DateTime Date { get; set; }

        // advice's text from legal expert
        [Display(Name = "Réponse : ")]
        [Required(ErrorMessage = "Veuillez remplir la réponse avant d'envoyer votre message")]
        public String AdviceText { get; set; }

        // advice's subject 
        public string AdviceSubject { get; set; }

        // foreign key advice request
        public AdviceRequest AdviceRequest { get; set; }

        public int AdviceRequestId { get; set; }

        // legal expert's id
        public Member Member { get; set; }

        public int MemberId { get; set; }
    }
}
