using Microsoft.AspNetCore.Hosting;
using Projet2.Models.BL.Interface;
using Projet2.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projet2.Models.BL.Service
{
    public class AssociationService : IAssociationService
    {
        private BddContext _bddContext;
        private IAddressService addressService;

        public AssociationService()
        {
            _bddContext = new BddContext();
            this.addressService = new AddressService();
        }

        public int CreateAssociation(AssociationInfoViewModel viewModel, int idRepresentative)
        {
            int idAddress = addressService.CreateAddress(viewModel.Address);
            viewModel.Association.AddressId = idAddress;
            viewModel.Association.AssociationRepresentativeId = idRepresentative;
            viewModel.Association.TicketService = false;
            viewModel.Association.DonationService = false;
            viewModel.Association.MemberService = false;
            viewModel.Association.IsPublished = false;
            _bddContext.Association.Add(viewModel.Association);
            _bddContext.SaveChanges();
            return viewModel.Association.Id;
        }

        public void ModifyAssociation(Association association)
        {
            _bddContext.Association.Update(association);
            _bddContext.SaveChanges();
        }

        public void ModifyAssociationViewModel(AssociationInfoViewModel viewModel)
        {
            addressService.ModifyAddress(viewModel.Address);
            viewModel.Association.AddressId = viewModel.Address.Id;
            _bddContext.Association.Update(viewModel.Association);
            _bddContext.SaveChanges();
        }

        public void DeleteAssociation(int id)
        {
            Association association = _bddContext.Association.Find(id);
            if (association != null)
            {
                addressService.DeleteAddress(association.AddressId);
                _bddContext.Association.Remove(association);
                _bddContext.SaveChanges();
            }
        }

        public Association GetAssociation(int id)
        {
            return _bddContext.Association.Find(id);
        }

        public List<Association> GetAllAssociations()
        {
            return _bddContext.Association.Where(a => a.IsPublished == true).ToList();
        }

        public List<Association> GetUnpublishedAssociations()
        {
            return _bddContext.Association.Where(a => a.IsPublished == false).ToList();
        }

        public List<AssociationSelectViewModel> GetAssociationSelectList()
        {
            List<AssociationSelectViewModel> unpublishedAssociations = new List<AssociationSelectViewModel>();
            List<Association> associationList = GetUnpublishedAssociations();
            foreach (Association association in associationList)
            {
                unpublishedAssociations.Add(new AssociationSelectViewModel
                {
                    Id = association.Id,
                    Name = association.Name
                });
            }return unpublishedAssociations;
        }

        public void ValidateAssociation(int id)
        {
            Association association = _bddContext.Association.FirstOrDefault(a => a.Id == id);
            association.IsPublished = true;
            _bddContext.Association.Update(association);
            _bddContext.SaveChanges();
        }

        public Association GetAssociationByDonationId(int id)
        {
            int AssociationId = (int)_bddContext.Donation.Find(id).AssociationId;
            return GetAssociation(AssociationId);
        }

        public Association GetAssociationByFundraisingId(int id)
        {
            int associationId = (int)_bddContext.Fundraising.Find(id).AssociationId;
            return GetAssociation(associationId);
        }

        public List<Association> GetHighlightedAssociations()
        {
            return _bddContext.Association.Where(a => a.IsHighlighted).ToList();
        }

        public List<Association> GetNotHighlightedAssociations()
        {
            return _bddContext.Association.Where(a => a.IsHighlighted == false).Where(a => a.IsPublished == true).ToList();
        }

        public List<Association> GetSearchAssociation(string searchCriteria)
        {
            List<Association> associations = new List<Association>();
            associations.Add(new Association { Name = searchCriteria });
            return associations;
        }
    }
}
