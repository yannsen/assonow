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

        public void CreateDonation(DonationViewModel viewModel)
        {
            if (viewModel.AssociationId != null)
            {
                if (viewModel.Frequency != null)
                {
                    RecurringDonation recurringDonation = new RecurringDonation { AssociationId = (int)viewModel.AssociationId, Amount = viewModel.Amount, MemberId = viewModel.MemberId, Frequency = (int)viewModel.Frequency };
                    _bddContext.RecurringDonation.Add(recurringDonation);
                    _bddContext.SaveChanges();
                    Donation donation = new Donation { AssociationId = viewModel.AssociationId, Amount = viewModel.Amount, MemberId = viewModel.MemberId, Date = DateTime.Today, RecurringDonationId = recurringDonation.Id};
                    _bddContext.Donation.Add(donation);
                    _bddContext.SaveChanges();
                }
                else
                {
                    Donation donation = new Donation { AssociationId = viewModel.AssociationId, Amount = viewModel.Amount, MemberId = viewModel.MemberId, Date = DateTime.Today};
                    _bddContext.Donation.Add(donation);
                    _bddContext.SaveChanges();
                }
            }
            else
            {
                Donation donation = new Donation { FundraisingId = viewModel.FundraisingId, Amount = viewModel.Amount, MemberId = viewModel.MemberId, Date = DateTime.Today};
                _bddContext.Donation.Add(donation);
                _bddContext.SaveChanges();
            }
        }
    }
}
