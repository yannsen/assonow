using Projet2.Models;

namespace Projet2.ViewModels
{
    public class PaymentViewModel
    {
        public int? DonationId { get; set; }

        public int? CommandId { get; set; }

        public int? ContributionId { get; set; }

        public string Amount { get; set; }
    }
}
