using System;

namespace Projet2.Models
{
    public class Fundraising
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int AssociationId { get; set; }

        public Association Association { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndingDate { get; set; }

        public int DesiredAmount { get; set; }

        public int CurrentAmount { get; set; }
    }
}
