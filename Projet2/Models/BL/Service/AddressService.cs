using Projet2.Models.BL.Interface;

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

        public void ModifyAddress(Address address)
        {
            _bddContext.Address.Update(address);
            _bddContext.SaveChanges();
        }
    }
}
