using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class AdviceListViewModel
    {
        public List<Advice> Advices { get; set; }

        public Advice SelectedAdvice { get; set; }

        public int SelectedAdviceId { get; set; }

        public AdviceRequest SelectedAdviceRequest { get; set; }

        public int AssociationId { get; set; }
    }
}
