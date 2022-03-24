using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class Advice
    {
        // Primary Key advice's id
        public int Id { get; set; }

        // advice's dates and times
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date du jour")]
        public DateTime Date { get; set; }

        // advice's text from legal expert
        [Display(Name = "Réponse : ")]
        [Required(ErrorMessage = "Veuillez remplir la réponse avant d'envoyer votre message")]
        public String AdviceText { get; set; }

        // advice's subject 
        [Display(Name = "Sujet ")]
        [StringLength(100)]
        public string AdviceSubject { get; set; }

        // foreign key advice request
        public int AdviceRequestId { get; set; }
        public AdviceRequest AdviceRequest { get; set; }
        
        // legal expert's id
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
