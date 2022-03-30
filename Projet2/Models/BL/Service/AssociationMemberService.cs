using Projet2.Models.BL.Interface;
using System.Linq;

namespace Projet2.Models.BL.Service
{
    public class AssociationMemberService : IAssociationMemberService
    {
        private BddContext _bddContext;
        public AssociationMemberService()
        {
            _bddContext = new BddContext();
        }

        public int CreateAssociationMember(int associationId, int memberId)
        {
            AssociationMember associationMember = new AssociationMember() { AssociationId = associationId, MemberId = memberId };
            _bddContext.AssociationMember.Add(associationMember);
            _bddContext.SaveChanges();
            return associationMember.Id;
        }

        public void DeleteAssociationMember(int id)
        {
            AssociationMember associationMember = _bddContext.AssociationMember.Find(id);
            if (associationMember != null)
            {
                _bddContext.AssociationMember.Remove(associationMember);
                _bddContext.SaveChanges();
            }
        }

        public bool DoMembershipExist(int associationId, int memberId)
        {
            return _bddContext.AssociationMember.Any(a => a.AssociationId == associationId && a.MemberId == memberId);
        }
    }
}
