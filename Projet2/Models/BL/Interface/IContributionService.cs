namespace Projet2.Models.BL.Interface
{
    public interface IContributionService
    {
        public int CreateContribution(int Amount, int MemberId, int AssociationId);

        public Contribution GetContribution(int memberId, int associationId);

        public void DeleteContribution(int memberId, int associationId);
    }
}
