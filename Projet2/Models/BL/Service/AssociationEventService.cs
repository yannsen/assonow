using Projet2.Models.BL.Interface;
using System;
using Projet2.ViewModels;
using Microsoft.AspNetCore.Authentication;

namespace Projet2.Models.BL.Service
{
    public class AssociationEventService : IAssociationEventService
    {
        private BddContext _bddContext;
         private IAddressService addressService;
        //AuthenticationService = new AuthentificationService();
        public int CreateAssociationEvent (AssociationEventInfoViewmodel viewModel)
        {
            int idAddress = addressService.CreateAddress(viewModel.Address);
            viewModel.AssociationEvent.AddressId = idAddress;
            //viewModel.Member.Role = "Representant";
            _bddContext.AssociationEvent.Add(viewModel.AssociationEvent);
            _bddContext.SaveChanges();
            return viewModel.AssociationEvent.Id;
        }

        public void ModifyAssociationEvent(AssociationEventInfoViewmodel viewModel)
        {
          addressService.ModifyAddress(viewModel.Address);
          _bddContext.AssociationEvent.Update(viewModel.AssociationEvent);
          _bddContext.SaveChanges();

        }
        public void DeleteAssociationEvent(int associationEventId)
        {
            AssociationEvent associationEvent = _bddContext.AssociationEvent.Find(associationEventId);
            if (associationEvent != null)
            {
                addressService.DeleteAddress(associationEvent.AddressId);
                _bddContext.AssociationEvent.Remove(associationEvent);
            }
        }



    }
}
