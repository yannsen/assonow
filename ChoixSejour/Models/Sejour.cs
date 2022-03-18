using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChoixSejour.Models
{
    public class Sejour
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le lieu doit être rempli.")]
        public string Lieu { get; set; }
        [Display(Name = "Téléphone")]
        [MaxLength(10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Le numéro de téléphone doit contenir 10 chiffres.")]
        public string Telephone { get; set; }
    }
}
