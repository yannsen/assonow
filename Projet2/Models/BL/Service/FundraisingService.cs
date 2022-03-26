using Projet2.Models.BL.Interface;
using Projet2.ViewModels;
using System.Collections.Generic;
using System.Linq;

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

        public List<Fundraising> GetAllFundraisings()
        {
            return _bddContext.Fundraising.Where(a => a.IsActive == true).ToList();
        }

        public List<Fundraising> GetFundraisingsToSearch(FundraisingListViewModel viewModel)
        {
            return _bddContext.Fundraising.Where(f => f.IsActive == viewModel.SearchIfActive)
                .Where(f => f.Name.Contains(viewModel.FundraisingNameToSearch)).ToList();
        }
    }
}
