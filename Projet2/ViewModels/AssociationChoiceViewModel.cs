//YS

using Microsoft.AspNetCore.Mvc.Rendering;
using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class AssociationChoiceViewModel
    {
        public AssociationEventInfoViewmodel AssociationEventInfo { get; set; }
        public List<AssociationSelectViewModel> selectedAssociations { get; set; }
        public int SelectedAssociationId { get; set; }

    }
}
