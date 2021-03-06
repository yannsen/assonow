using Projet2.ViewModels;
using System;
using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface IAssociationEventService // : IDisposable
    {
        public AssociationEvent GetAssociationEvent(int id);

        public int CreateAssociationEvent(AssociationEventInfoViewmodel viewModel);

        public void ModifyAssociationEvent(AssociationEventInfoViewmodel viewModel);

        public void DeleteAssociationEvent(int associationEventId);

        public List<Association> AssociationsRepresentative(int MemberConnectedId);

        public List<AssociationEvent> ListAssociationEvent(int MemberConnectedId);
        
        public List<AssociationEvent> GetAllAssociationEvents();
        
        public List<AssociationEvent> GetEventsByAssociation(int id);

        public AssociationEvent GetAssociationEventWithOrderId(int id);

        public void Update(AssociationEvent associationEvent);

        public List<AssociationEvent> GetAssociationEventToSearch(AssociationEventInfoViewmodel viewModel);

        public List<AssociationEvent> GetHighlightedAssociationEvents();

        public List<AssociationEvent> GetNotHighlightedAssociationEvents();
    }
}
