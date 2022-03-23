namespace Projet2.Models.BL.Interface
{
    public interface IAddressService
    {
        public int CreateAddress(Address address);

        public void DeleteAddress(int id);

        public void ModifyAddress(Address address);

        public Address GetAddress(int id);

        public Address GetAddressByAssociationId(int id);

        public Address GetAddressByMemberId(int id);
    }
}
