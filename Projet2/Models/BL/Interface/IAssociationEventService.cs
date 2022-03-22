using Projet2.ViewModels;
using System;

namespace Projet2.Models.BL.Interface
{
    public interface IAssociationEventService // : IDisposable
    {
        public int CreateAssociationEvent(AssociationEventInfoViewmodel viewModel, int memberId);
        public void ModifyAssociationEvent(AssociationEventInfoViewmodel viewModel);
        public void DeleteAssociationEvent(int associationEventId);
    }
}
