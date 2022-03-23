using Projet2.Models.BL.Interface;
using System.Linq;

namespace Projet2.Models.BL.Service
{
    public class AddressService : IAddressService
    {
        private BddContext _bddContext;
        public AddressService()
        {
            _bddContext = new BddContext();
        }
        public int CreateAddress(Address address)
        {
            _bddContext.Address.Add(address);
            _bddContext.SaveChanges();
            return address.Id;
        }

        public void DeleteAddress(int id)
        {
            Address address = _bddContext.Address.Find(id);
            if (address != null)
                _bddContext.Address.Remove(address);
        }

        public Address GetAddress(int id)
        {
            return _bddContext.Address.Find(id);
        }

        public Address GetAddressByAssociationId(int id)
        {
            int idAddress = _bddContext.Association.FirstOrDefault(a => a.Id == id).AddressId;
            return _bddContext.Address.FirstOrDefault(a => a.Id == idAddress);
        }

        public Address GetAddressByMemberId(int id)
        {
            int idAddress = _bddContext.Member.FirstOrDefault(a => a.Id == id).AddressId;
            return _bddContext.Address.FirstOrDefault(a => a.Id == idAddress);
        }

        public void ModifyAddress(Address address)
        {
            _bddContext.Address.Update(address);
            _bddContext.SaveChanges();
        }
    }
}
