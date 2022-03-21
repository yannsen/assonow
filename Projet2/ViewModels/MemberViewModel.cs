using Projet2.Models;
using System.ComponentModel.DataAnnotations;

namespace Projet2.ViewModels
{
    public class MemberViewModel
    {
        [Display(Name = "Pseudonyme :")]
        public string Pseudonym { get; set; }

        [Display(Name = "Mot de passe :")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La taille du mot de passe doit être comprise entre 6 et 15 caractères")]
        public string Password { get; set; }
        public bool Authentifie { get; set; }
    }
}
