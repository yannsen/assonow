using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class AssociationProfileViewModel
    {
        public Association Association { get; set; }

        public List<Fundraising> Fundraisings { get; set; }

        public List<AssociationEvent> Events { get; set; }
    }
}
