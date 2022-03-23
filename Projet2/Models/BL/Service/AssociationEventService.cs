using Projet2.Models.BL.Interface;
using System;
using Projet2.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Projet2.Models.BL.Service
{
    public class AssociationEventService : IAssociationEventService
    {
        private BddContext _bddContext;
         private IAddressService addressService;
        //AuthenticationService = new AuthentificationService();
        public AssociationEventService()
        {
            _bddContext = new BddContext();
            this.addressService = new AddressService();
        }

        public int CreateAssociationEvent (AssociationEventInfoViewmodel viewModel,int memberID)
        {
            //viewModel.Member.Role = "Representative";
            //List<AssociationMember> associationMembers  = _bddContext.AssociationMember.Where(a => a.MemberId == memberID);           
            //viewModel.AssociationEvent.
            int idAddress = addressService.CreateAddress(viewModel.Address);
            viewModel.AssociationEvent.AddressId = idAddress;


            if (viewModel.File.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    viewModel.File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    viewModel.AssociationEvent.Image = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(fileBytes));
                }
            }

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
