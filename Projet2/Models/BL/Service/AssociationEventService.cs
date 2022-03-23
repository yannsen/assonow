using Projet2.Models.BL.Interface;
using System;
using Projet2.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Projet2.Models.BL.Service
{
    public class AssociationEventService : IAssociationEventService
    {
        private BddContext _bddContext;
        private IAddressService addressEventService;
        //AuthenticationService = new AuthentificationService();
        public AssociationEventService()
        {
            _bddContext = new BddContext();
            this.addressEventService = new AddressService();
        }

        public int CreateAssociationEvent(AssociationEventInfoViewmodel viewModel, int memberID)
        {
            //viewModel.Member.Role = "Representative";
            //List<AssociationMember> associationMembers  = _bddContext.AssociationMember.Where(a => a.MemberId == memberID);           
            //viewModel.AssociationEvent.
            int idAddress = addressEventService.CreateAddress(viewModel.Address);
            viewModel.AssociationEvent.AddressId = idAddress;
            _bddContext.AssociationEvent.Add(viewModel.AssociationEvent);
            _bddContext.SaveChanges();
            return viewModel.AssociationEvent.Id;
        }

        public void ModifyAssociationEvent(AssociationEventInfoViewmodel viewModel)
        {
            addressEventService.ModifyAddress(viewModel.Address);
            _bddContext.AssociationEvent.Update(viewModel.AssociationEvent);
            _bddContext.SaveChanges();

        }
        public void DeleteAssociationEvent(int associationEventId)
        {
            AssociationEvent associationEvent = _bddContext.AssociationEvent.Find(associationEventId);
            if (associationEvent != null)
            {
                addressEventService.DeleteAddress(associationEvent.AddressId);
                _bddContext.AssociationEvent.Remove(associationEvent);
            }
        }

        // a Representative can manage more than one association
        // so this method retrieve the Id of all associations managed by this Representative
        //select  id from Association where RepresentativeId = MemberConnectedId
        public List<Association> AssociationsRepresentative(int MemberConnectedId)
        {
                       
            return _bddContext.Association.Where(a => a.Id == MemberConnectedId).ToList();
                
                
        }




    }
}
