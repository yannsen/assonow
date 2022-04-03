using Projet2.ViewModels;
using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface IFundraisingService
    {
        public Fundraising GetFundraising(int id);

        public List<Fundraising> GetAllFundraisings();

        public void Delete(Fundraising fundraising);

        public List<Fundraising> GetFundraisingsToSearch(FundraisingListViewModel viewModel);

        public Fundraising GetFundraisingByDonationId(int id);

        public void AddAmount(int id, int amount);

        public int Create(FundraisingInfoViewModel viewModel);

        public void Modify(Fundraising fundraising);

        public List<Fundraising> GetFundraisingsByAssociation(int id);

        public List<Fundraising> GetHighlightedFundraisings();

        public List<Fundraising> GetNotHighlightedFundraisings();
    }
}
