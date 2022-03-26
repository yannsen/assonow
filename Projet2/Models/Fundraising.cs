using System;

namespace Projet2.Models
{
    public class Fundraising
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }

        public int AssociationId { get; set; }

        public Association Association { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndingDate { get; set; }

        public int DesiredAmount { get; set; }

        public int CurrentAmount { get; set; }

        public bool IsActive { get; set; }

        public string Field { get; set; }

        public bool IsHighlighted { get; set; }
    }
}
