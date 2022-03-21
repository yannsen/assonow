namespace Projet2.Models.BL.Interface
{
    public interface IAssociationMemberService
    {
        public int CreateAssociationMember(int idAssociation, int idMember);
        public void DeleteAssociationMember(int id);
    }
}
