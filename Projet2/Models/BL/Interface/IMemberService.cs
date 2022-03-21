using Projet2.ViewModels;

namespace Projet2.Models.BL.Interface
{
    public interface IMemberService
    {
        public int CreateMember(MemberInfoViewModel viewModel);

        public void DeleteMember(int id);

        public void ModifyMember(MemberInfoViewModel viewModel);
    }
}
