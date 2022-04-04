using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface IAssociationMemberService
    {
        public int CreateAssociationMember(int idAssociation, int memberID);

        public void DeleteAssociationMember(int id);

        public bool DoMembershipExist(int associationId, int memberId);

        public List<Association> GetAssociationsForMember(int id);

        public List<Member> GetMembersForAssociation(int id);

        public AssociationMember GetAssociationMember(int MemberId, int AssociationId);
    }
}
