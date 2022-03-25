using Projet2.ViewModels;

namespace Projet2.Models.BL.Interface
{
    public interface IDonationService
    {
        public int CreateDonation(DonationViewModel viewModel);

        public Donation GetDonation(int id);
    }
}
