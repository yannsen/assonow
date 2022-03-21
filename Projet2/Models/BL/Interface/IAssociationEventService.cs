using System;

namespace Projet2.Models.BL.Interface
{
    public interface IAssociationEventService : IDisposable
    {
        public int CreateAssociationEvent(DateTime date, int ticketNumber, string eventType, string speakers, string artists, int addressId, int associationId);
        public void ModifyAssociationEvent(int associationEventId);
        public void DeleteAssociationEvent(int associationEventId);
    }
}
