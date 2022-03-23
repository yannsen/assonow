using Microsoft.AspNetCore.Http;
using Projet2.Models;
using System.ComponentModel.DataAnnotations;

namespace Projet2.ViewModels
{
    public class AssociationInfoViewModel
    {
        public Association Association { get; set; }
        public Address Address { get; set; }
        public AssociationMember AssociationMember { get; set; }

        [Display(Name = "Image :")]

        [Required(ErrorMessage = "Aucune image n'est fournie")]
        public IFormFile File { get; set; }
    }
}
