using Projet2.Models;
using System.ComponentModel.DataAnnotations;



namespace Projet2.ViewModels
{
    public class DonationViewModel
    {
        public int MemberId { get; set; }

#nullable enable
        public Association? Association { get; set; }

        public Fundraising? Fundraising { get; set; }
#nullable disable

        public bool isRecurrent { get; set; }

        [Display(Name = "Montant :")]
        [MaxLength(4, ErrorMessage = "Le montant doit être compris entre 1 et 9.999€")]
        [Required(ErrorMessage = "Le montant est obligatoire")]
        public string Amount { get; set; }
    }
}
