using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class Address
    {   
        [Key]
        public int Id { get; set; }

        [Display(Name = "Numéro de voie :")]
        [Required(ErrorMessage = "Le numéro de voie est obligatoire")]
        [MaxLength(5)]
        public string RoadNumber { get; set; }

        [Display(Name = "Voie :")]
        [Required(ErrorMessage = "Le nom de la voie est obligatoire")]
        [MaxLength(50)]
        public string Road { get; set; }

        [Display(Name = "Ville :")]
        [Required(ErrorMessage = "La ville est obligatoire")]
        [MaxLength(30)]
        public string City { get; set; }

        [Display(Name = "Code Postal :")]
        [Required(ErrorMessage = "Le code postal est obligatoire")]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Display(Name = "Pays :")]
        [Required(ErrorMessage = "Le pays est obligatoire")]
        [MaxLength(20)]
        public string Country { get; set; }
    }
}
