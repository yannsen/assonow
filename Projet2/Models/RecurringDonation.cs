namespace Projet2.Models
{
    public class RecurringDonation
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }

        public int AssociationId { get; set; }

        public Association Association { get; set; } 
    }
}
