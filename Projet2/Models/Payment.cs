using System;

namespace Projet2.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int? DonationId { get; set; }

        public int? CommandId { get; set; }

        public int? ContributionId { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
