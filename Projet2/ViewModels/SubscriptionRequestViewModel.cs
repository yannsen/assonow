using Microsoft.AspNetCore.Mvc.Rendering;
using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class SubscriptionRequestViewModel
    {
        public AssociationInfoViewModel AssociationInfo { get; set; }
        public List<AssociationSelectViewModel> unpublishedAssociations { get; set; }
        public int SelectedAssociationId { get; set; }
    }
}
