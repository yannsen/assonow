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

        public int Create(FundraisingInfoViewModel viewModel)
        {
            _bddContext.Fundraising.Add(viewModel.Fundraising);
            _bddContext.SaveChanges();
            return viewModel.Fundraising.Id;
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

        public Fundraising GetFundraisingByDonationId(int id)
        {
            int fundraisingId = (int)_bddContext.Fundraising.Find(id).AssociationId;
            return GetFundraising(fundraisingId);
        }

        public void AddAmount(int id, int amount)
        {
            Fundraising fundraising = GetFundraising(id);
            fundraising.CurrentAmount += amount;
            _bddContext.Fundraising.Update(fundraising);
            _bddContext.SaveChanges();
        }

        public void modify(Fundraising fundraising)
        {

        }
        public List<Fundraising> GetFundraisingsByAssociation(int id)
        {
            return _bddContext.Fundraising.Where(f => f.AssociationId == id).Where(f => f.IsActive).ToList();
        }
    }
}
