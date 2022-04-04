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

        public AssociationEvent GetAssociationEvent(int id)
        {
            return _bddContext.AssociationEvent.Find(id);
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

        public void Update(AssociationEvent associationEvent)
        {
            _bddContext.AssociationEvent.Update(associationEvent);
            _bddContext.SaveChanges();
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
        public List<AssociationEvent> GetAllAssociationEvents()
        {
            var query = from ae in _bddContext.AssociationEvent
                        select ae;

            var AllAssocationsEvent = query.ToList();
            return AllAssocationsEvent;

        }
        
        public List<AssociationEvent> GetEventsByAssociation(int id)
        {
            return _bddContext.AssociationEvent.Where(e => e.AssociationId == id).ToList();
        }



        public AssociationEvent GetAssociationEventWithOrderId(int id)
        {
            int idAssociationEvent = _bddContext.Ticket.FirstOrDefault(t => t.OrderId == id).AssociationEventId;
            return GetAssociationEvent(idAssociationEvent);
        }

        public List<AssociationEvent> GetAssociationEventToSearch(AssociationEventInfoViewmodel viewModel)
        {
            List<AssociationEvent> resultEvent = _bddContext.AssociationEvent.Where(f => f.EventTitle.Contains(viewModel.EventNameToSearch)).ToList();
            List<Association> resultAsso = _bddContext.Association.Where(a => a.Name.Contains(viewModel.AssociationNameToSearch)).ToList();
            List<int> resultAssoInt = new List<int>();
            foreach (Association asso in resultAsso)
                resultAssoInt.Add(asso.Id);
            List<AssociationEvent> rechercheFinale = new List<AssociationEvent>();
            foreach (AssociationEvent associationEvent in resultEvent)
            {
                if (resultAssoInt.Contains(associationEvent.AssociationId))
                {
                    rechercheFinale.Add(associationEvent);
                }
            }
            return rechercheFinale;
        }

        public List<AssociationEvent> GetHighlightedAssociationEvents()
        {
            return _bddContext.AssociationEvent.Where(a => a.IsHighlighted == true).ToList();
        }

        public List<AssociationEvent> GetNotHighlightedAssociationEvents()
        {
            return _bddContext.AssociationEvent.Where(a => a.IsHighlighted == false).ToList();
        }
    }

}