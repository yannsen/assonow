namespace Projet2.Models
{
    public class Contribution
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int MemberId { get; set; }

        public int AssociationId { get; set; }
    }
}
