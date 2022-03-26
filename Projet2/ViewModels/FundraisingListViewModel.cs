using Projet2.Controllers;
using Projet2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet2.ViewModels
{
    public class FundraisingListViewModel
    {
        public List<Fundraising> FundraisingsList { get; set; }

        public List<string> FundraisingsImage { get; set; }

        [Display(Name = "Nom de la collecte :")]
        public string FundraisingNameToSearch { get; set; }

        [Display(Name = "Collecte en cours :")]
        public bool SearchIfActive { get; set; }
    }
}
