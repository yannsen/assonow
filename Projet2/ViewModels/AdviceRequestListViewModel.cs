using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class AdviceRequestListViewModel
    {
        public List<AdviceRequest> AdviceRequestList { get; set; }

        public AdviceRequest SelectedAdviceRequest { get; set; }
        
        public Advice Advice { get; set; }
    }
}
