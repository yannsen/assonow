using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class HighlightedViewModel
    {
        public List<Association> HAssociations { get; set; }

        public List<Association> NHAssociations { get; set; }

        public List<Fundraising> HFundraisings { get; set; }

        public List<Fundraising> NHFundraisings { get; set; }

        public List<AssociationEvent> HEvents { get; set; }

        public List<AssociationEvent> NHEvents { get; set; }
    }
}
