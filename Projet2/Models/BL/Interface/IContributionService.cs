namespace Projet2.Models.BL.Interface
{
    public interface IContributionService
    {
        public int CreateContribution(int Amount, int MemberId, int AssociationId);
    }
}
