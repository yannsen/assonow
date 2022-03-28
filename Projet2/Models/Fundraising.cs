using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class Fundraising
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [Display(Name = "Nom :")]
        [MaxLength(30, ErrorMessage = "Le nom ne doit pas excéder 20 caractères")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Le nom ne doit contenir que des lettres")]
        public string Name { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        [Display(Name = "Description :")]
        [MaxLength(512, ErrorMessage = "La description ne doit pas excéder 512 caractères")]
        public string Description { get; set; }

        public int AssociationId { get; set; }

        public Association Association { get; set; }

        [Required(ErrorMessage = "La date de début est obligatoire")]
        [Display(Name = "Date de début :")]
        [DataType(DataType.Date, ErrorMessage = "Le format pour la date est : jj/mm/aaaa")]
        public DateTime StartingDate { get; set; }

        [Required(ErrorMessage = "La date de fin est obligatoire")]
        [Display(Name = "Date de fin :")]
        [DataType(DataType.Date, ErrorMessage = "Le format pour la date est : jj/mm/aaaa")]
        public DateTime EndingDate { get; set; }

        [Required(ErrorMessage = "Le montant désiré est obligatoire")]
        [Display(Name = "Montant désiré :")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Le montant ne doit contenir que des chiffres")]
        public int DesiredAmount { get; set; }

        public string Image { get; set; }

        public int CurrentAmount { get; set; }

        public bool IsActive { get; set; }

        public string Field { get; set; }

        public bool IsHighlighted { get; set; }
    }
}
