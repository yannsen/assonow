using Projet2.ViewModels;
using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface IFundraisingService
    {
        public Fundraising GetFundraising(int id);

        public List<Fundraising> GetAllFundraisings();

        public List<Fundraising> GetFundraisingsToSearch(FundraisingListViewModel viewModel);

        public Fundraising GetFundraisingByDonationId(int id);

        public void AddAmount(int id, int amount);
    }
}
