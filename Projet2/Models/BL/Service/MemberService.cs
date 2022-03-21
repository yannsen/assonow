using Projet2.Models.BL.Interface;
using Projet2.ViewModels;

namespace Projet2.Models.BL.Service
{
    public class MemberService : IMemberService
    {
        private BddContext _bddContext;
        private IAddressService addressService;
        private IAuthentificationService authentificationService;

        public MemberService()
        {
            _bddContext = new BddContext();
            addressService = new AddressService();
            authentificationService = new AuthentificationService();    
        }
        public int CreateMember(MemberInfoViewModel viewModel)
        {
            int idAddress = addressService.CreateAddress(viewModel.Address);
            viewModel.Member.AddressId = idAddress;
            viewModel.Member.Role = "Member";
            viewModel.Member.Password = authentificationService.EncodeMD5(viewModel.Password);
            _bddContext.Member.Add(viewModel.Member);
            _bddContext.SaveChanges();
            return viewModel.Member.Id;
        }

        public void DeleteMember(int id)
        {
            Member member = _bddContext.Member.Find(id);
            if (member != null)
            {
                addressService.DeleteAddress(member.AddressId);
                _bddContext.Member.Remove(member);
            }
        }

        public void ModifyMember(MemberInfoViewModel viewModel)
        {
            addressService.ModifyAddress(viewModel.Address);
            viewModel.Member.Password = authentificationService.EncodeMD5(viewModel.Password);
            _bddContext.Member.Update(viewModel.Member);
            _bddContext.SaveChanges();

        }
    }
}
