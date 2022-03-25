using Projet2.Models.BL.Interface;

namespace Projet2.Models.BL.Service
{
    public class FundraisingService : IFundraisingService
    {
        private BddContext _bddContext;
        private IAssociationService associationService;

        public FundraisingService()
        {
            _bddContext = new BddContext();
            this.associationService = new AssociationService();
        }

        public Fundraising GetFundraising(int id)
        {
            return _bddContext.Fundraising.Find(id);
        }
    }
}
