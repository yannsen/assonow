using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class FundraisingManagementViewModel
    {
        public List<Fundraising> Fundraisings { get; set; }

        public int AssociationId { get; set; }

        public Association Association { get; set; }
    }
}
