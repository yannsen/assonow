using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class HighlightedViewModel
    {
        public Dictionary<int, bool> Highlighted { get; set; }

        public Dictionary<int, string> HighlightedName { get; set; }

        public Dictionary<int, bool> ToHighlight { get; set; }

        public Dictionary<int, string> ToHighlightName { get; set; }
    }
}
