using Projet2.Models.BL.Interface;
using System;
using Projet2.ViewModels;

namespace Projet2.Models.BL.Service
{
    public class AssociationEventService : IAssociationEventService
    {
        private BddContext _bddContext;
         private IAddressService addressService;
        public int CreateAssociationEvent (DateTime date, int ticketNumber, string eventType, string speakers, string artists, int addressId, int associationId)
        {
            int idAddress = addressService.CreateAddress(viewModel.Address);
            viewModel.Member.AddressId = idAddress;
            return 
        }
    }
}
