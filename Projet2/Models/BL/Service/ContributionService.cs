using Projet2.Models.BL.Interface;

namespace Projet2.Models.BL.Service
{
    public class ContributionService : IContributionService
    {
        private BddContext _bddContext;

        public ContributionService()
        {
            _bddContext = new BddContext();
        }

        public int CreateContribution(int Amount, int MemberId, int AssociationId)
        {
            Contribution contribution = new Contribution { Amount = Amount, MemberId = MemberId, AssociationId = AssociationId };
            _bddContext.Add(contribution);
            _bddContext.SaveChanges();
            return contribution.Id;
        }
    }
}