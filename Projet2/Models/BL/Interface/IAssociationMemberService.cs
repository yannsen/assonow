namespace Projet2.Models.BL.Interface
{
    public interface IAssociationMemberService
    {
        public int CreateAssociationMember(int idAssociation, int memberID);
        public void DeleteAssociationMember(int id);
    }
}
