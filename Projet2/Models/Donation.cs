using System;

namespace Projet2.Models
{
    public class Donation
    {
        public int Id { get; set; } 

        public int? AssociationId { get; set; }

        public Association association { get; set; }

        public int? MemberId { get; set; }

        public Member Member { get; set; }

        public int? FundraisingId { get; set; }

        public Fundraising Fundraising { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }

        public int? RecurringDonationId { get; set; }

        public RecurringDonation RecurringDonation { get; set; }
    }
}
