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
        private IAddressService addressService;
      
        public AssociationEventService()
        {
            _bddContext = new BddContext();
            this.addressService = new AddressService();
        }

        public int CreateAssociationEvent(AssociationEventInfoViewmodel viewModel)
        {
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
            this._bddContext.SaveChanges();

        }
        public void DeleteAssociationEvent(int associationEventId)
        {
            AssociationEvent associationEvent = _bddContext.AssociationEvent.Find(associationEventId);
            if (associationEvent != null)
            {
                addressService.DeleteAddress(associationEvent.AddressId);
                _bddContext.AssociationEvent.Remove(associationEvent);
                _bddContext.SaveChanges();
            }
        }

        // a Representative can manage more than one association
        // so this method retrieve all associations managed by this Representative
        //select  id from Association where RepresentativeId = MemberConnectedId
        public List<Association> AssociationsRepresentative(int MemberConnectedId)
        {

            //var query =  from association in _bddContext.Association orderby association.Name where association.AssociationRepresentativeId == MemberConnectedId select association;
            //var associations = query.ToList();
            var associations = _bddContext.Association.Where(a => a.AssociationRepresentativeId == MemberConnectedId).ToList();

            return associations;
                
                
        }

        public List<AssociationEvent> ListAssociationEvent(int associationId)
        {

            //"SELECT AssociationEvent.* FROM AssociationEvent where AssociationId = associationId";
            var query = from ae in _bddContext.AssociationEvent
                        where ae.AssociationId == associationId
                        select ae;
            
            var EventAssocations = query.ToList();
            return EventAssocations;

        }



    }
}
