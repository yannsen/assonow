using Projet2.Models;
using System.ComponentModel.DataAnnotations;

namespace Projet2.ViewModels
{
    public class PaymentCreditCardViewModel
    {
        public PaymentViewModel PaymentViewModel { get; set; }

        public CreditCard NewCreditCard { get; set; }

        public CreditCard SavedCreditCard { get; set; }

        [Required(ErrorMessage = "Le mois est composé de 1 ou 2 chiffres")]
        [Display(Name = "Mois :")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "Le mois est composé de 1 ou 2 chiffres")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Le mois est composé de 1 ou 2 chiffres")]
        public string Month { get; set; }

        [Required(ErrorMessage = "L'année est composée de 4 chiffres")]
        [Display(Name = "Année :")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "L'année est composée de 4 chiffres")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "L'année est composée de 4 chiffres")]
        public string Year { get; set; }

        public bool SaveCard { get; set; }
    }
}
