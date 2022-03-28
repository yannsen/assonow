using Microsoft.AspNetCore.Http;
using Projet2.Models;
using System.ComponentModel.DataAnnotations;

namespace Projet2.ViewModels
{
    public class FundraisingInfoViewModel
    {
        public Fundraising Fundraising { get; set; }

        [Display(Name = "Image :")]

        [Required(ErrorMessage = "Aucune image n'est fournie")]
        public IFormFile File { get; set; }
    }
}
