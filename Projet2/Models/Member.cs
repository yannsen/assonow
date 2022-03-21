using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet2.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Display(Name = "Pseudonyme :")]
        [Required(ErrorMessage = "Le pseudonyme est obligatoire")]
        [MaxLength(15, ErrorMessage = "La taille du pseudonyme ne doit pas excéder 15 caractères")]
        public string Pseudonym { get; set; }

        [MaxLength(256)]
        public string Password { get; set; }

        public int? CreditCardId { get; set; }

        [Display(Name = "Prénom :")]
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [MaxLength(20, ErrorMessage = "La taille du prénom ne doit pas excéder 20 caractères")]
        public string Firstname { get; set; }

        [Display(Name = "Nom :")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [MaxLength(20, ErrorMessage = "La taille du nom ne doit pas excéder 20 caractères")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "L'adresse mail est obligatoire")]
        [Display(Name = "Adresse mail :")]
        [RegularExpression(@"^[A-Za-z0-9+_.-]+@(.+)$", ErrorMessage = "L'adresse mail n'est pas valide")]
        public string Mail { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public string Role { get; set; }

    }
}
