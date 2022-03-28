using Projet2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet2.ViewModels
{
    public class ListSearchAssociationViewModel
    {
        public List<Association> AssociationsList { get; set; }
        [Display(Name = "Recherche d'association :")]
        public string SearchName { get; set; }
        public List<Fundraising> Fundraisings { get; set; }
        public List<AssociationEvent> AssociationEvents { get; set; }
       
    }
}
