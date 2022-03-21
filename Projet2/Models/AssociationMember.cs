namespace Projet2.Models
{
    public class AssociationMember
    {
        public int Id { get; set; }
        public int AssociationId { get; set; }
        public Association Association { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
