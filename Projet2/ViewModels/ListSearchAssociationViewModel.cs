using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class ListSearchAssociationViewModel
    {
        public List<Association> AssociationList { get; set; }
        public string SearchCriteria { get; set; }
    }
}
