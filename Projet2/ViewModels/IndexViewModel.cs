using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class IndexViewModel
    {
        public List<Association> Associations { get; set; }

        public List<Fundraising> Fundraisings { get; set; }

        public List<AssociationEvent> AssociationEvents { get; set; }
    }
}
