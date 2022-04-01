using Projet2.Models.BL.Interface;
using System.Linq;

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

        public Contribution GetContribution(int memberId, int associationId)
        {
            return _bddContext.Contribution.FirstOrDefault(c => c.MemberId == memberId && c.AssociationId == associationId);
        }

        public void DeleteContribution(int memberId, int associationId)
        {
            if(GetContribution(memberId, associationId) != null)
                _bddContext.Contribution.Remove(GetContribution(memberId, associationId));
            _bddContext.SaveChanges();
        }
    }
}