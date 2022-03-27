using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        
        public int MemberId { get; set; }

        public Member Member { get; set; }

        [Required(ErrorMessage = "Le numéro de carte est composé de 16 chiffres")]
        [Display(Name = "Numéro de carte:")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Le numéro de carte est composé de 16 chiffres")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Le numéro de carte est composé de 16 chiffres")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [Display(Name = "Prénom :")]
        [MaxLength(20, ErrorMessage = "Le prénom ne doit pas excéder 20 caractères")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Le prénom ne doit contenir que des lettres")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [Display(Name = "Nom :")]
        [MaxLength(20, ErrorMessage = "Le nom ne doit pas excéder 20 caractères")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Le nom ne doit contenir que des lettres")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Le code CVC est composé de 3 chiffres")]
        [Display(Name = "Code CVC :")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Le code CVC est composé de 3 chiffres")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Le code CVC est composé de 3 chiffres")]
        public string Cvc { get; set; }

        [Required(ErrorMessage = "La date est obligatoire")]
        [Display(Name = "Date d'expiration :")]
        [DataType(DataType.Date, ErrorMessage = "Le format pour la date est : jj/mm/aaaa")]
        public DateTime DateTime { get; set; }
    }
}