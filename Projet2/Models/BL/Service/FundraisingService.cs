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

        public void Delete(Fundraising fundraising)
        {
            _bddContext.Fundraising.Remove(fundraising);
            _bddContext.SaveChanges();
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
            List<Fundraising> resultFund = _bddContext.Fundraising.Where(f => f.IsActive == viewModel.SearchIfActive)
                .Where(f => f.Name.Contains(viewModel.FundraisingNameToSearch)).ToList();
            List<Association> resultAsso = _bddContext.Association.Where(a => a.Name.Contains(viewModel.AssociationNameToSearch)).ToList();
            List<int> resultAssoInt = new List<int>();
            foreach(Association asso in resultAsso)
                resultAssoInt.Add(asso.Id);
            List<Fundraising> rechercheFinale = new List<Fundraising>();
            foreach(Fundraising fundraising in resultFund)
            {
                if(resultAssoInt.Contains(fundraising.AssociationId))
                {
                    rechercheFinale.Add(fundraising);
                }
            }
            return rechercheFinale;
        }

        public Fundraising GetFundraisingByDonationId(int id)
        {
            int fundraisingId = (int)_bddContext.Donation.Find(id).FundraisingId;
            return GetFundraising(fundraisingId);
        }

        public void AddAmount(int id, int amount)
        {
            Fundraising fundraising = GetFundraising(id);
            fundraising.CurrentAmount += amount;
            _bddContext.Fundraising.Update(fundraising);
            _bddContext.SaveChanges();
        }

        public void Modify(Fundraising fundraising)
        {
            Fundraising toUpdate = GetFundraising(fundraising.Id);
            toUpdate.Name = fundraising.Name;
            toUpdate.Description = fundraising.Description;
            if(fundraising.Image != null)
                toUpdate.Image = fundraising.Image;
            _bddContext.Fundraising.Update(toUpdate);
            _bddContext.SaveChanges();
        }

        public List<Fundraising> GetFundraisingsByAssociation(int id)
        {
            return _bddContext.Fundraising.Where(f => f.AssociationId == id).Where(f => f.IsActive).ToList();
        }

        public List<Fundraising> GetHighlightedFundraisings()
        {
            return _bddContext.Fundraising.Where(f => f.IsHighlighted == true).ToList();
        }

        public List<Fundraising> GetNotHighlightedFundraisings()
        {
            return _bddContext.Fundraising.Where(f => f.IsHighlighted == false).ToList();
        }
    }
}
