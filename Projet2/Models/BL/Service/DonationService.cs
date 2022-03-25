using Projet2.Models.BL.Interface;
using Projet2.ViewModels;
using System;
using System.Security.Claims;

namespace Projet2.Models.BL.Service
{
    public class DonationService : IDonationService
    {
        private BddContext _bddContext;
        private IFundraisingService fundraisingService;

        public DonationService()
        {
            _bddContext = new BddContext();
            this.fundraisingService = new FundraisingService();
        }

        public int CreateDonation(DonationViewModel viewModel)
        {
            Donation donation = new Donation();
            if (viewModel.Association != null)
            {
                if (viewModel.isRecurrent == true)
                {
                    RecurringDonation recurringDonation = new RecurringDonation { AssociationId = (int)viewModel.Association.Id, Amount = Int32.Parse(viewModel.Amount), MemberId = viewModel.MemberId};
                    _bddContext.RecurringDonation.Add(recurringDonation);
                    _bddContext.SaveChanges();
                    donation = new Donation { AssociationId = viewModel.Association.Id, Amount = Int32.Parse(viewModel.Amount), MemberId = viewModel.MemberId, Date = DateTime.Today, RecurringDonationId = recurringDonation.Id};
                    _bddContext.Donation.Add(donation);
                    _bddContext.SaveChanges();
                }
                else
                {
                    donation = new Donation { AssociationId = viewModel.Association.Id, Amount = Int32.Parse(viewModel.Amount), MemberId = viewModel.MemberId, Date = DateTime.Today};
                    _bddContext.Donation.Add(donation);
                    _bddContext.SaveChanges();
                }
            }
            else
            {
                donation = new Donation { FundraisingId = viewModel.Fundraising.Id, Amount = Int32.Parse(viewModel.Amount), MemberId = viewModel.MemberId, Date = DateTime.Today};
                _bddContext.Donation.Add(donation);
                _bddContext.SaveChanges();
            }
            return donation.Id;
        }

        public Donation GetDonation(int id)
        {
            return _bddContext.Donation.Find(id);
        }   
    }
}
